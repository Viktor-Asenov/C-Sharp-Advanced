using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            matrix[playerRow, playerCol] = '-';
            int counterCommands = 0;
            while (true)
            {
                counterCommands++;
                if (counterCommands > commands)
                {
                    Console.WriteLine("Player lost!");
                    matrix[playerRow, playerCol] = 'f';
                    break;
                }

                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        playerRow--;
                        break;
                    case "down":
                        playerRow++;
                        break;
                    case "left":
                        playerCol--;
                        break;
                    case "right":
                        playerCol++;
                        break;
                }

                if (!AreValidCoordinates(matrix, playerRow, playerCol))
                {
                    switch (command)
                    {
                        case "up":
                            playerRow = ResetCoordinates(matrix, playerRow, playerCol, command);
                            break;
                        case "down":
                            playerRow = ResetCoordinates(matrix, playerRow, playerCol, command);
                            break;
                        case "left":
                            playerCol = ResetCoordinates(matrix, playerRow, playerCol, command);
                            break;
                        case "right":
                            playerCol = ResetCoordinates(matrix, playerRow, playerCol, command);
                            break;
                    }

                    continue;
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    switch (command)
                    {
                        case "up":
                            playerRow--;
                            break;
                        case "down":
                            playerRow++;
                            break;
                        case "left":
                            playerCol--;
                            break;
                        case "right":
                            playerCol++;
                            break;
                    }

                    if (!AreValidCoordinates(matrix, playerRow, playerCol))
                    {
                        switch (command)
                        {
                            case "up":
                                playerRow = ResetCoordinates(matrix, playerRow, playerCol, command);
                                break;
                            case "down":
                                playerRow = ResetCoordinates(matrix, playerRow, playerCol, command);
                                break;
                            case "left":
                                playerCol = ResetCoordinates(matrix, playerRow, playerCol, command);
                                break;
                            case "right":
                                playerCol = ResetCoordinates(matrix, playerRow, playerCol, command);
                                break;
                        }

                        continue;
                    }

                    matrix[playerRow, playerCol] = '-';
                }
                else if (matrix[playerRow, playerCol] == 'T')
                {
                    switch (command)
                    {
                        case "up":
                            playerRow++;
                            break;
                        case "down":
                            playerRow--;
                            break;
                        case "left":
                            playerCol++;
                            break;
                        case "right":
                            playerCol--;
                            break;
                    }

                    if (!AreValidCoordinates(matrix, playerRow, playerCol))
                    {
                        switch (command)
                        {
                            case "up":
                                playerRow = ResetCoordinates(matrix, playerRow, playerCol, command);
                                break;
                            case "down":
                                playerRow = ResetCoordinates(matrix, playerRow, playerCol, command);
                                break;
                            case "left":
                                playerCol = ResetCoordinates(matrix, playerRow, playerCol, command);
                                break;
                            case "right":
                                playerCol = ResetCoordinates(matrix, playerRow, playerCol, command);
                                break;
                        }

                        continue;
                    }

                    matrix[playerRow, playerCol] = '-';
                }
                else if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    Console.WriteLine("Player won!");
                    break;
                }                
            }

            Print(matrix);
        }

        public static bool AreValidCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        public static int ResetCoordinates(char[,] matrix, int row, int col, string command)
        {
            switch (command)
            {
                case "up":
                    row = matrix.GetLength(0) - 1;
                    return row;
                case "down":
                    row = 0;
                    return row;
                case "left":
                    col = matrix.GetLength(1) - 1;
                    return col;
                case "right":
                    col = 0;
                    return col;
                default:
                    return 0;
            }
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
