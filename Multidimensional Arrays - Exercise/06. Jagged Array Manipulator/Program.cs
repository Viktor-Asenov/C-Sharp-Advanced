using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] rowData = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                matrix[row] = new double[rowData.Length];
                matrix[row] = rowData;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }                    
                }
                else if (matrix[row].Length < matrix[row + 1].Length
                    || matrix[row].Length > matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }                    
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] input = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                double value = double.Parse(input[3]);

                if (input[0] == "Add")
                {
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length )
                    {
                        matrix[row][col] += value;
                    }                    
                }
                else if (input[0] == "Subtract")
                {
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                }                
                
                command = Console.ReadLine();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
