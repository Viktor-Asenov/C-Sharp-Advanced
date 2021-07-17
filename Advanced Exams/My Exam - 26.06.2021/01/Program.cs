using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            for (int row = 0; row < size; row++)
            {
                string[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                matrix[row] = new char[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    char currentChar = char.Parse(rowData[col]);
                    matrix[row][col] = currentChar;                    
                }
            }

            int collectedTokens = 0;
            int opponentTokens = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Gong")
                {
                    break;
                }

                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);

                if (commandArgs[0] == "Find")
                {
                    if (AreValidCoordinates(matrix, row, col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                }
                else if (commandArgs[0] == "Opponent")
                {
                    string direction = commandArgs[3];
                    if (AreValidCoordinates(matrix, row, col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col] = '-';
                            for (int i = 0; i < 3; i++)
                            {
                                switch (direction)
                                {
                                    case "up":
                                        row--;
                                        if (AreValidCoordinates(matrix, row, col))
                                        {
                                            if (matrix[row][col] == 'T')
                                            {
                                                opponentTokens++;
                                                matrix[row][col] = '-';
                                            }
                                        }
                                        break;
                                    case "down":
                                        row++;
                                        if (AreValidCoordinates(matrix, row, col))
                                        {
                                            if (matrix[row][col] == 'T')
                                            {
                                                opponentTokens++;
                                                matrix[row][col] = '-';
                                            }
                                        }
                                        break;
                                    case "left":
                                        col--;
                                        if (AreValidCoordinates(matrix, row, col))
                                        {
                                            if (matrix[row][col] == 'T')
                                            {
                                                opponentTokens++;
                                                matrix[row][col] = '-';
                                            }
                                        }
                                        break;
                                    case "right":
                                        col++;
                                        if (AreValidCoordinates(matrix, row, col))
                                        {
                                            if (matrix[row][col] == 'T')
                                            {
                                                opponentTokens++;
                                                matrix[row][col] = '-';
                                            }
                                        }
                                        break;
                                }
                            }                            
                        }
                    }
                }
            }

            PrintMatrix(matrix);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        public static bool AreValidCoordinates(char[][] matrix, int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }
            if (row >= matrix.GetLength(0) || col >= matrix[row].Length)
            {
                return false;
            }

            return true;
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
