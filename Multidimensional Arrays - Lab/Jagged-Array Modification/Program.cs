using System;
using System.Linq;

namespace Jagged_Array_Modification
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

            string command = Console.ReadLine();

            while (command != "END")
            {
                var splitted = command.Split();
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);

                if (splitted[0] == "Add")
                {
                    if (row < 0 || col < 0 || row > matrix.GetLength(0) - 1 || col > matrix.GetLength(1) - 1)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        matrix[row, col] += value;
                    }
                }
                else
                {
                    if (row < 0 || col < 0 || row > matrix.GetLength(0) - 1 || col > matrix.GetLength(1) - 1)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        matrix[row, col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
