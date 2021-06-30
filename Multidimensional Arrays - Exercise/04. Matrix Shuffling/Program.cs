using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);                    

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] currentData = command.Split();

                if (!command.Contains("swap") || currentData.Length < 5 || currentData.Length > 5)
                {
                    Console.WriteLine("Invalid input!");                    
                }
                else
                {
                    int row1 = int.Parse(currentData[1]);
                    int col1 = int.Parse(currentData[2]);
                    int row2 = int.Parse(currentData[3]);
                    int col2 = int.Parse(currentData[4]);

                    if (row1 < 0 || row1 > matrix.GetLength(0) || col1 < 0 || col1 > matrix.GetLength(1)
                        || row2 < 0 || row2 > matrix.GetLength(0) || col2 < 0 || col2 > matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");                        
                    }
                    else
                    {
                        string firstValue = matrix[row1, col1];
                        string secondValue = matrix[row2, col2];

                        matrix[row1, col1] = secondValue;
                        matrix[row2, col2] = firstValue;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
