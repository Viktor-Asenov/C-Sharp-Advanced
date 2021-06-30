using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumPrimaryDiagonal += matrix[row, col];
                    col++;
                }
            }

            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    sumSecondaryDiagonal += matrix[row, col];
                    col--;
                }
            }

            int difference = 0;

            if (sumPrimaryDiagonal >= sumSecondaryDiagonal )
            {
                difference = sumPrimaryDiagonal - sumSecondaryDiagonal;
            }
            else
            {
                difference = sumSecondaryDiagonal - sumPrimaryDiagonal;
            }

            Console.WriteLine($"{difference}");
        }
    }
}
