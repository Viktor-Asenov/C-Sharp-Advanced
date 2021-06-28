using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {                
                int sumColumn = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {                    ;
                    sumColumn += matrix[row,col];
                }

                Console.WriteLine(sumColumn);
            }
        }
    }
}
