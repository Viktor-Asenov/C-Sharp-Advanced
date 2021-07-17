using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            matrix[beeRow, beeCol] = '.';
            int countPolinatedFlowers = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "up":
                        beeRow--;
                        break;
                    case "down":
                        beeRow++;
                        break;
                    case "left":
                        beeCol--;
                        break;
                    case "right":
                        beeCol++;
                        break;
                }

                if (!AreValidCoordinates(matrix, beeRow, beeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    countPolinatedFlowers++;
                    matrix[beeRow, beeCol] = '.';
                }
                else if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    switch (command)
                    {
                        case "up":
                            beeRow--;
                            break;
                        case "down":
                            beeRow++;
                            break;
                        case "left":
                            beeCol--;
                            break;
                        case "right":
                            beeCol++;
                            break;
                    }

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        countPolinatedFlowers++;
                        matrix[beeRow, beeCol] = '.';
                    }
                }
            }

            if (countPolinatedFlowers < 5)
            {
                matrix[beeRow, beeCol] = 'B';
                int neededFlowers = 5 - countPolinatedFlowers;
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {neededFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countPolinatedFlowers} flowers!");
            }

            Print(matrix);
        }

        public static bool AreValidCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        public static void Print(char[,] matrix)
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
