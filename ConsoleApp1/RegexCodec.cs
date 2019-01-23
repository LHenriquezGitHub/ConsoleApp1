using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;



namespace Greenhouse.Utilities
{

    public class RegexCodec
    {
        public const string REGEX_GROUP_MONTH = "Month";
        public const string REGEX_GROUP_DAY = "Day";
        public const string REGEX_GROUP_YEAR = "Year";
        public const string REGEX_GROUP_HOUR = "Hour";
        public const string REGEX_SUBFOLDER = "Subfolder";
        public const string REGEX_ENTITYID = "EntityId";

        private static Regex groupMatchRegex = new Regex("{[^{}]+}");
        private static Regex groupMatchMask = new Regex(@"\([^()]+\)");
        private static Regex zeroes = new Regex("{0+}");
        private static Regex digits = new Regex(@"\\d{(\d{1,3})}");

        private const string ABC_REGEX = "([A-Za-z]+)";
        private const string ABC123_REGEX = "([A-Za-z0-9]+)";
        private const string ENTITYID_REGEX = "(?<EntityId>[A-Za-z0-9_]+)";
        private const string MM_REGEX = "(?<Month>0[1-9]|1[012])";
        private const string DD_REGEX = "(?<Day>0[1-9]|[12][0-9]|3[01])";
        private const string YYYY_REGEX = "(?<Year>20\\d{2})";
        private const string HH_REGEX = "(?<Hour>2[0-3]|1[0-9]|0[0-9])";
        //any valid URI character (per Azure spec)
        private const string SUBFOLDER_REGEX = "(?<Subfolder>([A-Za-z0-9]|[-\\.\\?\\[\\]\\$\\*]|[_~:#@!&',;=`])+)";

        private const string ABC_MASK = "{ABC}";
        private const string ABC123_MASK = "{ABC123}";
        private const string ENTITYID_MASK = "{ENTITYID}";
        private const string MM_MASK = "{MM}";
        private const string DD_MASK = "{DD}";
        private const string YYYY_MASK = "{YYYY}";
        private const string HH_MASK = "{HH}";
        //any valid URI character (per Azure spec)
        private const string SUBFOLDER_MASK = "{SUBFOLDER}";
        private const string PREFIX = "PREFIX=";




        private static string[] fileDateTimeGroups = new string[] { "Day", "Month", "Year" };
        private string FileNameMask { get; set; }
        public Regex FileNameRegex { get; private set; }
        public RegexCodec(string mask)
        {

            FileNameMask = mask;
            FileNameRegex = new Regex(string.Format("^{0}$", groupMatchRegex.Replace(FileNameMask, ReplaceMaskGroup)));
        }

        public RegexCodec(Regex regex)
        {
            FileNameRegex = regex;
            FileNameMask = groupMatchMask.Replace(regex.ToString(), ReplaceRegexGroup);
        }

        public bool TryParse(string fileName)
        {
            bool success = true;
            string[] groupNames = FileNameRegex.GetGroupNames();
            if (!FileNameRegex.IsMatch(fileName) || !fileDateTimeGroups.All(s => groupNames.Contains(s)))
            {
                return false;
            }
            Match match = FileNameRegex.Match(fileName);
            string strDate = string.Format("{0}-{1}-{2}", match.Groups[REGEX_GROUP_MONTH].Value,
                                                          match.Groups[REGEX_GROUP_DAY].Value,
                                                          match.Groups[REGEX_GROUP_YEAR].Value);

            FileNameDate = TryParseExact(strDate);
            FileNameHour = match.Groups[REGEX_GROUP_HOUR].Success ? Convert.ToInt32(match.Groups[REGEX_GROUP_HOUR].Value) : (int?)null;
            Subfolder = match.Groups[REGEX_SUBFOLDER].Value;
            EntityId = match.Groups[REGEX_ENTITYID].Value;
            return success;
        }

        public DateTime? FileNameDate { get; private set; }
        public int? FileNameHour { get; private set; }
        public string Subfolder { get; private set; }
        public string EntityId { get; private set; }

        /// <summary>
        /// Converts simple user-friendly filename mask into regex
        /// </summary>
        /// <param name="str">The string mask to parse</param>
        /// <returns>A regex string representation of the mask. </returns>
        public string ParseToRegex(string str)
        {
            str = str.Replace(".", "\\.");
            string result = groupMatchRegex.Replace(str, ReplaceMaskGroup);
            return result;
        }

        public string ParseToFileNameMask(string str)
        {
            string result = groupMatchMask.Replace(str, ReplaceRegexGroup);
            return result;
        }


        private string ReplaceMaskGroup(Match m)
        {
            switch (m.Value)
            {
                case ABC_MASK:
                    return ABC_REGEX;
                case ABC123_MASK:
                    return ABC123_REGEX;
                case MM_MASK:
                    return MM_REGEX;
                case DD_MASK:
                    return DD_REGEX;
                case YYYY_MASK:
                    return YYYY_REGEX;
                case HH_MASK:
                    return HH_REGEX;
                case ENTITYID_MASK:
                    return ENTITYID_REGEX;
                default:
                    if (zeroes.IsMatch(m.Value))
                    {
                        int zeroCount = m.Value.Length - 2;
                        return "(\\d{" + zeroCount + "})";
                    }
                    else
                    {
                        //if (m.Value == SUBFOLDER_MASK) {
                        //    return SUBFOLDER_REGEX;
                        //}
                        return m.Value;
                    }
            }
        }

        private string ReplaceRegexGroup(Match m)
        {
            switch (m.Value)
            {
                case ABC_REGEX:
                    return ABC_MASK;
                case ABC123_REGEX:
                    return ABC123_MASK;
                case MM_REGEX:
                    return MM_MASK;
                case DD_REGEX:
                    return DD_MASK;
                case YYYY_REGEX:
                    return YYYY_MASK;
                case HH_REGEX:
                    return HH_MASK;
                case ENTITYID_REGEX:
                    return ENTITYID_MASK;
                default:
                    Match match = digits.Match(m.Value);
                    if (match.Groups.Count > 1)
                    {
                        StringBuilder sb = new StringBuilder("{");
                        for (int i = 0; i < Convert.ToInt32(match.Groups[1].Value); i++)
                        {
                            sb.Append("0");
                        }
                        sb.Append("}");
                        return sb.ToString();
                    }
                    else
                    {
                        //if (m.Value == SUBFOLDER_REGEX) {
                        //    return SUBFOLDER_MASK;
                        //}
                        return m.Value;
                    }
            }
        }

        public static string GetUsage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Regex Mask Usage");
            sb.AppendLine("----------------");
            sb.AppendLine(string.Format("Alpha: {0}", ABC_MASK));
            sb.AppendLine(string.Format("Numeric: {0} (as many 0's as there are digits)", "{0000}"));
            sb.AppendLine(string.Format("Alphanumeric: {0}", ABC123_MASK));
            sb.AppendLine(string.Format("EntityID: {0}", ENTITYID_MASK));
            sb.AppendLine(string.Format("Month: {0}", MM_MASK));
            sb.AppendLine(string.Format("Day: {0}", DD_MASK));
            sb.AppendLine(string.Format("Year: {0}", YYYY_MASK));
            sb.AppendLine(string.Format("Hour: {0}", HH_MASK));
            sb.AppendLine("----------------");
            sb.AppendLine("Note: any text specified outside of these mask elements will be treated as a literal");
            sb.AppendLine("e.g: an expression of: sly_stallone_{ABC123}_{000000}.zip would match the 'sly_stallone' and the '.zip' as well as all the underscores literally (no pattern-matching).");

            return sb.ToString();
        }

        public static DateTime? TryParseExact(string text)
        {
            DateTime date;
            return DateTime.TryParseExact(text, "MM-dd-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out date) ? date : (DateTime?)null;
        }
    }

   
}
