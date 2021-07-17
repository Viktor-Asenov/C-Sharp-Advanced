using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currRow = 0;
            int currCol = 0;
            char[,] matrix = new char[n, n];
            List<Tuple<int, int>> pillars = new List<Tuple<int, int>>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (rowData[j] == 'S')
                    {
                        currRow = i;
                        currCol = j;
                    }
                    if (rowData[j] == 'O')
                    {
                        pillars.Add(new Tuple<int, int>(i, j));
                    }
                    matrix[i, j] = rowData[j];
                }
            }

            bool isInTheBakery = true;
            int moneyCollected = 0;

            while (isInTheBakery && moneyCollected < 50)
            {
                matrix[currRow, currCol] = '-';
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        currRow--;
                        isInTheBakery = isValidIndex(currRow, currCol, n);
                        if (isInTheBakery)
                        {
                            if (matrix[currRow, currCol] == 'O')
                            {
                                matrix[currRow, currCol] = '-';
                                foreach (var coordinate in pillars)
                                {
                                    if (currRow != coordinate.Item1 && currCol != coordinate.Item2)
                                    {
                                        currRow = coordinate.Item1;
                                        currCol = coordinate.Item2;
                                    }
                                }
                            }
                            else if (char.IsDigit(matrix[currRow, currCol]))
                            {
                                moneyCollected += int.Parse(matrix[currRow, currCol].ToString());

                            }
                            matrix[currRow, currCol] = 'S';
                        }
                        break;
                    case "down":
                        currRow++;
                        isInTheBakery = isValidIndex(currRow, currCol, n);

                        if (isInTheBakery)
                        {
                            if (matrix[currRow, currCol] == 'O')
                            {
                                matrix[currRow, currCol] = '-';
                                foreach (var coordinate in pillars)
                                {
                                    if (currRow != coordinate.Item1 && currCol != coordinate.Item2)
                                    {
                                        currRow = coordinate.Item1;
                                        currCol = coordinate.Item2;
                                    }
                                }
                            }
                            else if (char.IsDigit(matrix[currRow, currCol]))
                            {
                                moneyCollected += int.Parse(matrix[currRow, currCol].ToString());

                            }
                            matrix[currRow, currCol] = 'S';
                        }
                        break;
                    case "left":
                        currCol--;
                        isInTheBakery = isValidIndex(currRow, currCol, n);

                        if (isInTheBakery)
                        {
                            if (matrix[currRow, currCol] == 'O')
                            {
                                matrix[currRow, currCol] = '-';
                                foreach (var coordinate in pillars)
                                {
                                    if (currRow != coordinate.Item1 && currCol != coordinate.Item2)
                                    {
                                        currRow = coordinate.Item1;
                                        currCol = coordinate.Item2;
                                    }
                                }

                            }
                            else if (char.IsDigit(matrix[currRow, currCol]))
                            {
                                moneyCollected += int.Parse(matrix[currRow, currCol].ToString());
                            }
                            matrix[currRow, currCol] = 'S';
                        }
                        break;
                    case "right":
                        currCol++;
                        isInTheBakery = isValidIndex(currRow, currCol, n);

                        if (isInTheBakery)
                        {
                            if (matrix[currRow, currCol] == 'O')
                            {
                                matrix[currRow, currCol] = '-';
                                foreach (var coordinates in pillars)
                                {
                                    if (currRow != coordinates.Item1 && currCol != coordinates.Item2)
                                    {
                                        currRow = coordinates.Item1;
                                        currCol = coordinates.Item2;
                                    }
                                }
                            }
                            else if (char.IsDigit(matrix[currRow, currCol]))
                            {
                                moneyCollected += int.Parse(matrix[currRow, currCol].ToString());
                            }
                            matrix[currRow, currCol] = 'S';
                        }
                        break;
                    default:
                        break;
                }
            }

            if (isInTheBakery == false)
            {
                Console.WriteLine($"Bad news, you are out of the bakery.");
            }
            if (moneyCollected >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {moneyCollected}");

            PrintMatrix(matrix);
        }

        static bool isValidIndex(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
        static void PrintMatrix(char[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

    }
}