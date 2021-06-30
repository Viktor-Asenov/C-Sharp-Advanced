using System;
using System.Linq;

namespace _02._Squares_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    string current = matrix[row, col];

                    if (matrix[row, col] == current && matrix[row + 1,col] == current
                        && matrix[row, col + 1] == current && matrix[row + 1, col + 1] == current)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
