using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse.Data.Model.Setup;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Program
    {


        /// <summary>
        /// Group by SourceFilename by renaming the Key 
        /// These Keys will be use to get the Max LastWriteTimeUtc 
        /// to prevent duplicate source file type
        /// </summary>
        /// <param name="sourceFilename"></param>
        /// <returns></returns>
        public static string ConvertToSourceFilename(string sourceFilename)
        {
            var nameArray = sourceFilename.Split('_');
            var nameArrayLength = nameArray.Length;
            var nameStartIndex = 4; 
            var nameLoopLength = (nameArrayLength - 8) + nameStartIndex;
            var filename = string.Empty;
            for (int i = 4; i < nameLoopLength; i++)
            {
                filename += nameArray[i];
            }
            return filename;
        }

        static void Main(string[] args)
        {


            List<FileClass> _importFiles = new List<FileClass>() {

                 new FileClass() {Name = "dcm_account49701_match_table_activity_cats_20190121_20190122_032810_2063247693.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:28:13.154Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_activity_types_20190121_20190122_034056_2063234129.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:40:58.256Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_ad_placement_assignments_20190121_20190122_040259_2063247699.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T03:03:01.951Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_ads_20190121_20190122_034059_2063234131.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:41:02.355Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_ads_20190121_20190122_035432_2063234131.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:54:35.241Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_ads_20190121_20190122_035432_2063234131.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T03:54:35.241Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_ads_20190121_20190122_035432_2063234131.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T04:54:35.241Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_advertisers_20190121_20190122_034542_2063247597.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:45:44.447Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_browsers_20190121_20190122_034535_2063247599.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:45:37.056Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_campaigns_20190121_20190122_034059_2063247596.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:41:02.172Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_cities_20190121_20190122_040257_2063247700.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T03:02:59.546Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_creative_ad_assignments_20190121_20190122_040304_2063234122.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T03:03:07.254Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_creatives_20190121_20190122_040303_2063234121.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T03:03:05.848Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_custom_creative_fields_20190121_20190122_034052_2063247694.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:40:54.993Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_custom_floodlight_variables_20190121_20190122_034050_2063247590.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:40:52.587Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_custom_rich_media_20190121_20190122_032757_2063234118.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:27:59.887Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_designated_market_areas_20190121_20190122_032801_2063247593.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:28:03.949Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_keyword_value_20190121_20190122_032804_2063234125.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:28:07.458Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_operating_systems_20190121_20190122_032757_2063234123.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:27:59.412Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_paid_search_20190121_20190122_040249_2063234130.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T03:02:50.943Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_placement_cost_20190121_20190122_032810_2063247598.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:28:13.131Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_placements_20190121_20190122_034109_2063247591.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:41:12.056Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_sites_20190121_20190122_034050_2063247695.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T02:40:53.28Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_states_20190121_20190122_040254_2063247592.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T03:02:56.346Z").UtcDateTime }
                ,new FileClass() {Name = "dcm_account49701_match_table_empire_states_of_mind_20190121_20190122_040254_2063247592.csv.gz",LastWriteTimeUtc = DateTimeOffset.Parse("2019-01-22T03:02:56.346Z").UtcDateTime }

            };

            var importFileDictionary =_importFiles.GroupBy(item => ConvertToSourceFilename(item.Name)).ToDictionary(d => d.Key, f => f.ToList());
            var temp2 = importFileDictionary.Select(d => d.Value.OrderByDescending(f => f.LastWriteTimeUtc).FirstOrDefault()).ToList();


            var uno = "";





















            var result = "{\"Success\":true,\"ServiceResults\":[{\"Success\":true,\"Operation\":1,\"Server\":{\"ServerID\":2,\"ServerAlias\":\"QA-DATALOAD\",\"ServerMachineName\":\"DTIONEPR01-UE1T.cloud.vivaki.com\",\"ServerName\":\"DTIONEPR01-UE1T\",\"ServerIP\":\"172.18.30.177\",\"ServerTypeID\":1,\"ClusterID\":2,\"TimeZoneString\":\"Eastern Standard Time;-300;(UTC-05:00) Eastern Time (US & Canada);Eastern Standard Time;Eastern Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];\",\"IsActive\":true,\"CreatedDate\":\"2017-06-29T16:31:04.113\",\"LastUpdated\":\"2018-02-06T20:31:13.783\"},\"ServiceName\":\"GreenhouseWinService$QA-DATALOAD\",\"Status\":1,\"Error\":null,\"AdditionalInfo\":\"GreenhouseWinService$QA-DATALOAD transitioned from Running to Stopped\",\"Message\":\"Attempting Stop for service: GreenhouseWinService$QA-DATALOAD on server: DTIONEPR01-UE1T...Success! Status is: Stopped. Additional info: GreenhouseWinService$QA-DATALOAD transitioned from Running to Stopped\"},{\"Success\":true,\"Operation\":1,\"Server\":{\"ServerID\":5,\"ServerAlias\":\"QA-IMPORT\",\"ServerMachineName\":\"DTIONEIM01-UE1T.cloud.vivaki.com\",\"ServerName\":\"DTIONEIM01-UE1T\",\"ServerIP\":\"172.18.30.247\",\"ServerTypeID\":1,\"ClusterID\":2,\"TimeZoneString\":\"Eastern Standard Time;-300;(UTC-05:00) Eastern Time (US & Canada);Eastern Standard Time;Eastern Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];\",\"IsActive\":true,\"CreatedDate\":\"2017-06-29T16:43:54.15\",\"LastUpdated\":\"2017-06-29T16:43:54.15\"},\"ServiceName\":\"GreenhouseWinService$QA-IMPORT\",\"Status\":1,\"Error\":null,\"AdditionalInfo\":\"GreenhouseWinService$QA-IMPORT was already stopped y'know, forgetaboutit\",\"Message\":\"Attempting Stop for service: GreenhouseWinService$QA-IMPORT on server: DTIONEIM01-UE1T...Success! Status is: Stopped. Additional info: GreenhouseWinService$QA-IMPORT was already stopped y'know, forgetaboutit\"},{\"Success\":true,\"Operation\":1,\"Server\":{\"ServerID\":6,\"ServerAlias\":\"QA-WEBSERVER\",\"ServerMachineName\":\"DTIONEWS01-UE1T.cloud.vivaki.com\",\"ServerName\":\"DTIONEWS01-UE1T\",\"ServerIP\":\"172.18.30.245\",\"ServerTypeID\":3,\"ClusterID\":2,\"TimeZoneString\":\"Eastern Standard Time;-300;(UTC-05:00) Eastern Time (US & Canada);Eastern Standard Time;Eastern Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];\",\"IsActive\":true,\"CreatedDate\":\"2017-06-29T16:44:54.96\",\"LastUpdated\":\"2017-06-29T16:44:54.96\"},\"ServiceName\":\"GreenhouseWinService$QA-WEBSERVER\",\"Status\":1,\"Error\":null,\"AdditionalInfo\":\"GreenhouseWinService$QA-WEBSERVER was already stopped y'know, forgetaboutit\",\"Message\":\"Attempting Stop for service: GreenhouseWinService$QA-WEBSERVER on server: DTIONEWS01-UE1T...Success! Status is: Stopped. Additional info: GreenhouseWinService$QA-WEBSERVER was already stopped y'know, forgetaboutit\"},{\"Success\":true,\"Operation\":1,\"Server\":{\"ServerID\":233,\"ServerAlias\":\"QA-AGGIMPORT\",\"ServerMachineName\":\"DTIONEIM02-UE1T.cloud.vivaki.com\",\"ServerName\":\"DTIONEIM02-UE1T\",\"ServerIP\":\"172.18.30.198\",\"ServerTypeID\":1,\"ClusterID\":2,\"TimeZoneString\":\"Eastern Standard Time;-300;(UTC-05:00) Eastern Time (US & Canada);Eastern Standard Time;Eastern Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];\",\"IsActive\":true,\"CreatedDate\":\"2019-01-14T22:17:56.087\",\"LastUpdated\":\"2019-01-14T22:17:56.087\"},\"ServiceName\":\"GreenhouseWinService$QA-AGGIMPORT\",\"Status\":1,\"Error\":null,\"AdditionalInfo\":\"GreenhouseWinService$QA-AGGIMPORT was already stopped y'know, forgetaboutit\",\"Message\":\"Attempting Stop for service: GreenhouseWinService$QA-AGGIMPORT on server: DTIONEIM02-UE1T...Success! Status is: Stopped. Additional info: GreenhouseWinService$QA-AGGIMPORT was already stopped y'know, forgetaboutit\"}]}";
            var response = JsonConvert.DeserializeObject<Greenhouse.Deployment.WCF.ServiceCallResponse>(result);
                                 
            var one = $"search index=\"0\" *1*";
            var two = System.Net.WebUtility.HtmlEncode(one);
            var three = System.Net.WebUtility.UrlEncode(one);


            var si1 = SplunkIndex("LOCALDEV");
            var si2 = SplunkIndex("PROD");
            var si3 = SplunkIndex("TEST");
            var si4 = SplunkIndex("DEV");
            var si5 = SplunkIndex("");


            //cld_conversions_feed_2018121000.done
            var filename = "GP_cld_conversions_feed_01_2018121000.tar.gz";
            var nameArray = filename.Split('_');
            var nameArrayLength = nameArray.Length;

            var colNames = nameArray.Where((name, index) => index > 0 && index != (nameArrayLength-2));



            var doneFileNamestring = string.Join("_", colNames).Replace(".tar.gz", ".done");


            List<FileClass> fileList = new List<FileClass>
            {
               new FileClass() {  Name = "GP_cld_standard_display_feed_01_2018120300.tar.gz", Extension = ".gz" },
               new FileClass() {  Name = "GP_cld_standard_display_feed_01_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_01_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_01_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_02_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_02_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_02_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_02_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_03_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_03_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_03_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_03_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_04_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_04_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_04_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_04_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_05_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_05_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_05_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_05_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_06_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_06_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_06_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_06_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_07_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_07_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_07_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_07_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_08_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_08_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_08_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_08_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_09_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_09_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_09_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_09_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_10_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_10_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_10_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_10_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_11_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_11_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_11_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_11_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_12_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_12_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_12_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_12_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_13_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_13_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_13_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_13_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_14_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_14_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_14_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_14_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_15_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_15_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_15_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_15_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_16_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_16_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_16_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_16_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_17_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_17_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_17_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_17_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_18_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_18_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_18_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_18_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_19_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_19_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_19_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_19_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_20_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_20_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_20_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_20_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_21_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_21_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_21_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_21_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_22_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_22_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_22_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_22_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_23_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_23_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_23_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_23_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_24_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_24_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_24_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_24_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_25_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_25_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_25_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_25_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_26_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_26_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_26_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_26_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_27_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_27_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_27_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_27_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_28_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_28_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_28_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_28_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_29_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_29_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_29_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_29_2018120318.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_30_2018120300.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_30_2018120305.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_30_2018120315.tar.gz", Extension = ".gz"},
               new FileClass() {  Name = "GP_cld_standard_display_feed_30_2018120318.tar.gz", Extension = ".gz"},

               //new FileClass() {  Name = "CLD_standard_display_feed_2018120300.done", Extension = ".done" },
               //new FileClass() {  Name = "CLD_standard_display_feed_2018120305.done", Extension = ".done" },
               //new FileClass() {  Name = "CLD_standard_display_feed_2018120315.done", Extension = ".done" },
               new FileClass() {  Name = "CLD_standard_display_feed_2018120318.done", Extension = ".done" }


            };
            var dList = fileList.Where(file => file.Extension == ".done").ToList();
            var fList = fileList.Where(file => file.Extension != ".done").ToList();

            GroupFiles(fList, dList);


            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }

        private static object MethodTemp(DateTime lastWriteTimeUtc)
        {
            var dt = lastWriteTimeUtc;
            return dt;
        }

        private static void GroupFiles(List<FileClass> fileList, List<FileClass> doneList)
        {
            var result = fileList.GroupBy(x => GetDoneNameBatch(x.Name)).ToDictionary(gfl => gfl.Key.ToLower(), gfl => gfl.ToList());
            foreach (var item in result)
            {
                var k = item.Key.Substring(item.Key.Length - 7, 2);
            }
            //var newlist = result.
            //     Where(x => doneList.Any(dl => dl.Name.Equals(x.Key, StringComparison.CurrentCultureIgnoreCase))).
            //     ToDictionary(gfl => gfl.Key, gfl => gfl.Value.ToList());


            foreach (var item in doneList)
            {
                result.Remove(item.Name.ToLower());
            }

        }

        /// <summary>
        /// The new Splunk instance indexes are named after environments.
        /// datalake (For PROD), staging_datalake, qa_datalake, dev_datalake
        /// </summary>
        public static string SplunkIndex (string env)
        {
            //get
            //{
                string indexPrefix = string.Empty;
                var environment = env;
                switch (environment)
                {
                    case "LOCALDEV":
                        indexPrefix = "dev";
                        break;
                    case "PROD":
                        break;
                    case "TEST":
                        indexPrefix = "qa";
                        break;
                    default:
                        indexPrefix = environment.ToLower();
                        break;
                }
                string indexName = (string.IsNullOrEmpty(indexPrefix)) ? $"datalake": $"{indexPrefix}_datalake";
                return indexName;
            //}
        }

        private static string GetDoneNameBatch(string Name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name.Replace("GP_", ""));
            sb.Replace(sb.ToString(), sb.ToString().Replace(".tar.gz", ".done"));
            sb.Replace(sb.ToString(), sb.ToString().Remove(sb.ToString().LastIndexOf("_") - 2, 3));
            return sb.ToString();
        }

        private static void RenameDoneFiles(List<FileClass> dList)
        {
            StringBuilder sb;
            List<FileClass> fc = new List<FileClass>();
            foreach (var doneFile in dList)
            {
                for (int i = 0; i < 30; i++)
                {
                    sb = new StringBuilder();
                    sb.Append(doneFile.Name);
                    sb.Insert(0, "GP_");

                    sb.Insert(doneFile.Name.Length - 16, (i.ToString().Length == 1) ? "_0" + i.ToString() : "_" + i.ToString());

                    doneFile.Name = sb.ToString();
                    fc.Add(doneFile);
                }
            }
        }

        static int SubstractDiagonalValues(int[,] matrix, int index, int tracker)
        {
            if (index == 0) { return 0; }
            index = index - 1;
            var sum = matrix[index, index] - matrix[index, (tracker - 1) - index];

            return sum + SubstractDiagonalValues(matrix, index, tracker);

        }

        public static int SubstractDiagonalValues(int[,] ar)
        {
            var leftSum = 0;
            var rightSum = 0;
            var matrixLegth = Math.Sqrt(ar.Length);
            var tracker = matrixLegth;
            for (int i = 0; i < matrixLegth; i++)
            {
                leftSum += ar[i, i];
                int rightIndex = (int)((tracker - 1) - i);
                rightSum += ar[i, rightIndex];
            }

            return Math.Abs(leftSum - rightSum);
        }


        public static int Factorial(int number)
        {
            if (number == 0 || number == 1) { return 1; }
            return number * Factorial(number - 1);
        }
        public static int Fibonacci(int number)
        {
            if (number == 0 || number == 1) { return 1; }
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        public static void IsPrimeNumber(int number)
        {
            if (number == 2 || number == 3) { Console.Write($"{number},"); return; }
            for (int i = 1; i <= number; i++)
            {
                if (i != 1 && i != number && !(number % i == 0)) { Console.Write($"{number},"); return; }
            }
        }
    }

    public static class ExtendIFile
    {
        public static void GetDoneName(this FileClass fileClass)
        {
            string result = string.Empty;

        }
    }

    public static class DictionaryHelper
    {
        /// <summary>
        /// Remove elements from Dictionary<Key, Item>
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target"></param>
        /// <param name="keys"></param>
        public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> target,
                                           List<TKey> keys)
        {
            var tmp = new Dictionary<TKey, TValue>();

            foreach (var key in keys)
            {
                TValue val;
                if (target.TryGetValue(key, out val))
                {
                    tmp.Add(key, val);
                }
            }

            target.Clear();

            foreach (var kvp in tmp)
            {
                target.Add(kvp.Key, kvp.Value);
            }
        }
    }


}

