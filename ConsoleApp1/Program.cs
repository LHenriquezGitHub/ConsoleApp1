
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleApp1.SolveProblems;
using Greenhouse.Data.Model.Setup;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Program
    {


        static void Main(string[] args)
        {

            int[][] arr = new int[6][];

            arr[0] = new int[] { 1, 1, 1, 0, 0, 0 };
            arr[1] = new int[] { 0, 1, 0, 0, 0, 0 };
            arr[2] = new int[] { 1, 1, 1, 0, 0, 0 };
            arr[3] = new int[] { 0, 0, 2, 4, 4, 0 };
            arr[4] = new int[] { 0, 0, 0, 2, 0, 0 };
            arr[5] = new int[] { 0, 0, 1, 2, 4, 0 };

            //arr[0] = new int[] { -9, -9, -9, 1, 1, 1 };
            //arr[1] = new int[] { 0, -9, 0, 4, 3, 2 };
            //arr[2] = new int[] { -9, -9, -9, 1, 2, 3 };
            //arr[3] = new int[] { 0, 0, 8, 6, 6, 0 };
            //arr[4] = new int[] { 0, 0, 0, -2, 0, 0 };
            //arr[5] = new int[] { 0, 0, 1, 2, 4, 0 };


            //arr[0] = new int[] { -1, -1, 0, -9, -2, -2 };
            //arr[1] = new int[] { -2, -1, -6, -8, -2, -5 };
            //arr[2] = new int[] { -1, -1, -1, -2, -3, -4 };
            //arr[3] = new int[] { -1, -9, -2, -4, -4, -5 };
            //arr[4] = new int[] { -7, -3, -3, -2, -9, -9 };
            //arr[5] = new int[] { -1, -3, -1, -2, -4, -5 };

            var maxSubsetArraySum = HackerRank.HourglassSum(arr);

            string stringPath = "DDUUUUDD";
            var numberOfValleys = HackerRank.CountingValleys(stringPath.Length, stringPath);

            string singleString = "a";
            long numberOfChar = 1000000000000;

            var numberofOccurrence = HackerRank.RepeatedString(singleString, numberOfChar);

            int[] clouds = new int[] { 0, 1, 0, 0, 0, 1, 0 };
            var cloudJumps = HackerRank.JumpingOnClouds(clouds);


            var mimPageFlips = HackerRank.DrawingBook(5, 4);

            int[] socks = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20, 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            var socksPair = HackerRank.MatchingSocksAvailable(socks);

            #region overload get

            //var one = Util.Get(1);

            #endregion  

            #region interface
            /*
            Animal animal = new Dog();            
            animal.WhatDoYouSay();
            animal = new Cat();
            animal.WhatDoYouSay();
            animal = new Unknown();
            animal.WhatDoYouSay();
            animal = new NoAnimal();
            animal.WhatDoYouSay();
            animal.WhatDoYouEat();

            //Regex regexByDate = new Regex(@"(\d+)[-.\/](\d+)[-.\/](\d+)");
            //Console.WriteLine(regexByDate.Match("blahblah20190101.csv").Value);
            //Console.WriteLine(regexByDate.Match("blahblah2019-01-01.csv").Value);
            //Console.WriteLine(regexByDate.Match("blahblah2019-1-1.csv").Value);
            //Console.WriteLine(regexByDate.Match("blahblah2019-1-01.csv").Value);
            //Console.WriteLine(regexByDate.Match("blahblah_20182019-01-1.csv").Value);
            */
            #endregion

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }

        public static void MatchDate()
        {
            List<DateTime> importedDates = new List<DateTime>()
            {
                new DateTime (2019,03,28),new DateTime (2019,03,27),
                new DateTime (2019,03,26),new DateTime (2019,03,25),
                new DateTime (2019,03,24),new DateTime (2019,03,23)
            };

            List<string> remoteDatesStr1 = new List<string>()
            {
                "20190328", "20190327", "20190326", "20190325", "20190324", "20190323",
                "20190322", "20190321", "20190320", "20190319", "20190318", "20190317"
            };
            List<string> remoteDatesStr2 = new List<string>()
            {
                "2019-03-28", "2019-03-27", "2019-03-26", "2019-03-25", "2019-03-24", "2019-03-23",
                "2019-03-22", "2019-03-21", "2019-03-20", "2019-03-19", "2019-03-18", "2019-03-17"
            };
            List<string> remoteDatesStr3 = new List<string>()
            {
                "2019/03/28", "2019/03/27", "2019/03/26", "2019/03/25", "2019/03/24", "2019/03/23",
                "2019/03/22", "2019/03/21", "2019/03/20", "2019/03/19", "2019/03/18", "2019/03/17"
            };

            var dates1 = remoteDatesStr1.Select(date => DateTime.ParseExact(date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
            var dates2 = remoteDatesStr2.Select(date => DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture));
            var dates3 = remoteDatesStr3.Select(date => DateTime.ParseExact(date, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            //List<DateTime> remoteDates1 = importedDates.Select(fileDate => fileDate).ToList();
            //List<DateTime> remoteDates2 = importedDates.Select(fileDate => fileDate).ToList();
            //List<DateTime> remoteDates3 = importedDates.Select(fileDate => fileDate).ToList();

            //remoteDates1.Add(new DateTime(2019, 03, 11));
            //remoteDates2.Add(new DateTime(2019, 03, 12));
            //remoteDates3.Add(new DateTime(2019, 03, 13));

            var importedFilesByDate = importedDates.Select(fileDate => fileDate).ToList();

            //var remoteFilesByDateMissing1 = (importedFilesByDate?.Count() < 1) ? remoteDates1 : remoteDates1.Except(importedFilesByDate).Select(f => f);
            //var remoteFilesByDateMissing2 = (importedFilesByDate?.Count() < 1) ? remoteDates2 : remoteDates2.Except(importedFilesByDate).Select(f => f);
            //var remoteFilesByDateMissing3 = (importedFilesByDate?.Count() < 1) ? remoteDates2 : remoteDates3.Except(importedFilesByDate).Select(f => f);

            var DateMissing1 = (importedFilesByDate?.Count() < 1) ? dates1 : dates1.Except(importedFilesByDate);
            var DateMissing2 = (importedFilesByDate?.Count() < 1) ? dates2 : dates2.Except(importedFilesByDate);
            var DateMissing3 = (importedFilesByDate?.Count() < 1) ? dates3 : dates3.Except(importedFilesByDate);

            //Create file group by date and import
            var remoteFileGroupsMissing1 = DateMissing1.GroupBy(fileItems => fileItems).ToDictionary(dictionaryFileItem => dictionaryFileItem.Key, fileItem => fileItem);
            var remoteFileGroupsMissing2 = DateMissing2.GroupBy(fileItems => fileItems).ToDictionary(dictionaryFileItem => dictionaryFileItem.Key, fileItem => fileItem);
            var remoteFileGroupsMissing3 = DateMissing2.GroupBy(fileItems => fileItems).ToDictionary(dictionaryFileItem => dictionaryFileItem.Key, fileItem => fileItem);
        }

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
            //var nameLoopLength = (nameArrayLength - 8) + nameStartIndex;
            var nameLoopLength = nameArrayLength - nameStartIndex;
            var filename = string.Empty;
            for (int i = 4; i < nameLoopLength; i++)
            {
                filename += nameArray[i];
            }
            return filename;
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
        public static string SplunkIndex(string env)
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
            string indexName = (string.IsNullOrEmpty(indexPrefix)) ? $"datalake" : $"{indexPrefix}_datalake";
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
            if (number <= 1) return number;
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        public static int FibonacciMemoization(int number, int[] f)
        {
            if (number <= 1) return number;
            //if(f[number])
            var value = Fibonacci(number - 1) + Fibonacci(number - 2);
            f[number] = value;
            return value;
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