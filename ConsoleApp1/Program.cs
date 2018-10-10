using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] matrix = new int[,]
            {{ 4, 2, 4, 8},
             { 3, 8, 8, 4},
             { 4, 2, 4, 8},
             { 4, 2, 4, 4}};

            var tracker = (int)Math.Sqrt(matrix.Length);
            Console.WriteLine(Math.Abs( SubstractDiagonalValues(matrix, tracker, tracker)));


            Console.WriteLine(WriteLeftToRightSum(matrix));
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }

        static int SubstractDiagonalValues(int[,] matrix, int index, int tracker)
        {
            if (index == 0) { return 0; }
            index = index - 1;
            var sum = matrix[index, index] - matrix[index, (tracker - 1) - index];

            return sum + SubstractDiagonalValues(matrix, index, tracker);
            
        }

        public static int WriteLeftToRightSum(int[,] ar)
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
    }
}
