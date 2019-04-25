using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SolveProblems
{
    public static class HackerRank
    {
        public static int MatchingSocksAvailable(int[] ar)
        {
            int sockWithMatchingColor = 0;
            var distinctSocks = ar.Distinct().ToArray();

            for (int i = 0; i < distinctSocks.Length; i++)
            {
                var countSocksPair = ar.Where(s => s == distinctSocks[i]).ToArray();
                sockWithMatchingColor = sockWithMatchingColor + (countSocksPair.Length / 2);
            }

            return sockWithMatchingColor;
        }

        public static int DrawingBook(int pageCount, int targetPage)
        {
            int frontToBackFlips = 0;
            int backToFrontFlips = 0;

            if (targetPage == 1) { return 0; }
            else if (targetPage == pageCount) { return 0; }
            else
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    frontToBackFlips++;
                    if (i == targetPage) break;
                }
                frontToBackFlips = frontToBackFlips / 2;

                for (int i = pageCount; i >= 1; i--)
                {
                    if (i == targetPage)
                    {
                        if (pageCount % 2 == 0) backToFrontFlips++;
                        break;
                    }
                    backToFrontFlips++;
                }
                backToFrontFlips = backToFrontFlips / 2;
            }

            return (frontToBackFlips < backToFrontFlips) ? frontToBackFlips : backToFrontFlips;
        }

        public static int JumpingOnClouds(int[] clouds)
        {
            //int[] clouds = new int[] { 0, 1, 0, 0, 0, 1, 0 };
            //clouds =  new int[] { 0, 1, 0, 0, 0, 1, 0, 0};
            //clouds = new int[] { 0, 0, 1, 0, 0, 1, 0 };
            //clouds = new int[] { 0, 0, 0, 0, 1, 0 }; 


            var jumpTracker = 0;
            var jumpStep = 0;

            if (clouds[0] == 1) { throw new Exception(); }

            for (int i = 0; i < clouds.Length; i++)
            {
                if (jumpTracker != i) continue;

                var indexPlusOne = i + 1;
                var indexPlusTwo = i + 2;
                var indexCount = clouds.Length - 1;

                if (clouds[i] == 0)
                {
                    if (indexPlusTwo <= indexCount && clouds[indexPlusTwo] == 0)
                    {
                        jumpTracker = jumpTracker + 2;
                        jumpStep++;
                    }
                    else if (indexPlusOne <= indexCount && clouds[indexPlusOne] == 0)
                    {
                        jumpTracker = jumpTracker + 1;
                        jumpStep++;
                    }

                }
            }

            return jumpStep;
        }

        public static long RepeatedString(string singleString, long numberOfChar)
        {
            var countOccurrence = numberOfChar / singleString.Length;
            var remainder = numberOfChar % singleString.Length;
            var aCount = singleString.Count(s => s.Equals('a'));
            var rCount = singleString.Substring(0, (int)remainder).Count(s => s.Equals('a'));
            return (countOccurrence * aCount) + rCount;
        }

        public static int CountingValleys(int numberOfSteps, string stringPath)
        {
            int d = 0, u = 0, valleyCount = 0;
            for (int i = 0; i < numberOfSteps; i++)
            {
                if (stringPath[i].Equals('D')) { d++; }
                else { u++; }

                if ((u == d) && (d - u) == 0 && stringPath[i].Equals('U'))
                    valleyCount++;
            }

            return valleyCount;
        }

        public static int HourglassSum(int[][] arr)
        {
            int[][] trackSum = new int[4][];
            trackSum[0] = new int[] { 0, 0, 0, 0 };
            trackSum[1] = new int[] { 0, 0, 0, 0 };
            trackSum[2] = new int[] { 0, 0, 0, 0 };
            trackSum[3] = new int[] { 0, 0, 0, 0 };



            for (int outer = 0; outer <= arr.Length - 1; outer++)
            {
                for (int inner = 0; inner <= arr.Length - 1; inner++)
                {
                    if (outer >= 0 && outer <= 2 && inner >= 0 && inner <= 2)
                    {
                        if ((outer == 1 && inner == 0) || (outer == 1 && inner == 2)) { }
                        else { trackSum[0][0] += arr[outer][inner]; }
                    }
                    if (outer >= 0 && outer <= 2 && inner >= 1 && inner <= 3)
                    {
                        if ((outer == 1 && inner == 1) || (outer == 1 && inner == 3)) { }
                        else { trackSum[0][1] += arr[outer][inner]; }
                    }
                    if (outer >= 0 && outer <= 2 && inner >= 2 && inner <= 4)
                    {
                        if ((outer == 1 && inner == 2) || (outer == 1 && inner == 4)) { }
                        else { trackSum[0][2] += arr[outer][inner]; }
                    }
                    if (outer >= 0 && outer <= 2 && inner >= 3 && inner <= 5)
                    {
                        if ((outer == 1 && inner == 3) || (outer == 1 && inner == 5)) { }
                        else { trackSum[0][3] += arr[outer][inner]; }
                    }

                    /**/
                    if (outer >= 1 && outer <= 3 && inner >= 0 && inner <= 2)
                    {
                        if ((outer == 2 && inner == 0) || (outer == 2 && inner == 2)) { }
                        else { trackSum[1][0] += arr[outer][inner]; }
                    }
                    if (outer >= 1 && outer <= 3 && inner >= 1 && inner <= 3)
                    {
                        if ((outer == 2 && inner == 1) || (outer == 2 && inner == 3)) { }
                        else { trackSum[1][1] += arr[outer][inner]; }
                    }
                    if (outer >= 1 && outer <= 3 && inner >= 2 && inner <= 4)
                    {
                        if ((outer == 2 && inner == 2) || (outer == 2 && inner == 4)) { }
                        else { trackSum[1][2] += arr[outer][inner]; }
                    }
                    if (outer >= 1 && outer <= 3 && inner >= 3 && inner <= 5)
                    {
                        if ((outer == 2 && inner == 3) || (outer == 2 && inner == 5)) { }
                        else { trackSum[1][3] += arr[outer][inner]; }
                    }

                    /**/
                    if (outer >= 2 && outer <= 4 && inner >= 0 && inner <= 2)
                    {
                        if ((outer == 3 && inner == 0) || (outer == 3 && inner == 2)) { }
                        else { trackSum[2][0] += arr[outer][inner]; }
                    }
                    if (outer >= 2 && outer <= 4 && inner >= 1 && inner <= 3)
                    {
                        if ((outer == 3 && inner == 1) || (outer == 3 && inner == 3)) { }
                        else { trackSum[2][1] += arr[outer][inner]; }
                    }
                    if (outer >= 2 && outer <= 4 && inner >= 2 && inner <= 4)
                    {
                        if ((outer == 3 && inner == 2) || (outer == 3 && inner == 4)) { }
                        else { trackSum[2][2] += arr[outer][inner]; }
                    }
                    if (outer >= 2 && outer <= 4 && inner >= 3 && inner <= 5)
                    {
                        if ((outer == 3 && inner == 3) || (outer == 3 && inner == 5)) { }
                        else { trackSum[2][3] += arr[outer][inner]; }
                    }

                    /**/
                    if (outer >= 3 && outer <= 5 && inner >= 0 && inner <= 2)
                    {
                        if ((outer == 4 && inner == 0) || (outer == 4 && inner == 2)) { }
                        else { trackSum[3][0] += arr[outer][inner]; }
                    }
                    if (outer >= 3 && outer <= 5 && inner >= 1 && inner <= 3)
                    {
                        if ((outer == 4 && inner == 1) || (outer == 4 && inner == 3)) { }
                        else { trackSum[3][1] += arr[outer][inner]; }
                    }
                    if (outer >= 3 && outer <= 5 && inner >= 2 && inner <= 4)
                    {
                        if ((outer == 4 && inner == 2) || (outer == 4 && inner == 4)) { }
                        else { trackSum[3][2] += arr[outer][inner]; }
                    }
                    if (outer >= 3 && outer <= 5 && inner >= 3 && inner <= 5)
                    {
                        if ((outer == 4 && inner == 3) || (outer == 4 && inner == 5)) { }
                        else { trackSum[3][3] += arr[outer][inner]; }
                    }
                }
            }

            int maxSum = trackSum.FirstOrDefault().FirstOrDefault();
            for (int i = 0; i < trackSum.GetLength(0); i++)
            {
                var max = trackSum[i].Max();
                maxSum = (maxSum > max) ? maxSum : max;
            }
            return maxSum;
        }
    }
}