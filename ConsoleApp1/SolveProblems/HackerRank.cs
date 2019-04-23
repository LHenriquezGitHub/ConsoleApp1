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
                    if (i == targetPage) {
                        if(pageCount % 2 == 0) backToFrontFlips++;
                        break;
                    }
                    backToFrontFlips++;
                }
                backToFrontFlips = backToFrontFlips / 2;
            }

            return (frontToBackFlips < backToFrontFlips) ? frontToBackFlips : backToFrontFlips;
        }


        public  static int JumpingOnClouds(int[] clouds)
        {
            var avoidTracker = 0;
            var jumpTracker = 0;

            if (clouds[0] == 1) { throw new Exception(); }

            for (int i = 0; i < clouds.Length; i++)
            {       
                
                if (clouds[i] == 0)
                {
                    if (clouds[i + 2] == 0)
                    {
                        jumpTracker = jumpTracker + 2;
                    }
                    else if (clouds[i + 1] == 0)
                    {
                        jumpTracker = jumpTracker + 1;
                    }

                    if (jumpTracker % 2 == 1)
                    {

                    }
                }


                if (clouds[i] == 1)
                {

                }

                if (clouds[i] == clouds.Length - 2 && clouds[i] == 0)
                {
                    break;
                }
                if (clouds[i] == 0)
                {
                    
                }
                else
                {

                }

                if (clouds[i] == clouds.Length - 1 || clouds[i] == clouds.Length - 2)
                {

                }
                cloudTracker++;
            }

            return cloudTracker;
        }
    }
}