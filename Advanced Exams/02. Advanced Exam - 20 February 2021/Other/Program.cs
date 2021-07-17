using System;
using System.Collections.Generic;
using System.Linq;

namespace Other
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> attackCoordinates = new List<int[]>();
            int sizeMatrix = int.Parse(Console.ReadLine());
            string[] coordinates = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] currentCoordinates = coordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                attackCoordinates.Add(currentCoordinates);
            }

            int availableShipsFirstPlayer = 0;
            int availableShipsSecondPlayer = 0;

            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(rowData[col]);
                    if (matrix[row, col] == '<')
                    {
                        availableShipsFirstPlayer++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        availableShipsSecondPlayer++;
                    }
                }
            }

            int countDestroyedFirstPlayer = 0;
            int countDestroyedSecondPlayer = 0;
            int counter = -1;
            while (availableShipsFirstPlayer > 0 && availableShipsSecondPlayer > 0
                    && attackCoordinates.Count - 1 > counter)
            {
                counter++;
                int attackRow = attackCoordinates[counter][0];
                int attackCol = attackCoordinates[counter][1];
                if (counter % 2 == 0)
                {
                    if (AreValidCoordinates(matrix, attackRow, attackCol)
                        && matrix[attackRow, attackCol] == '<')
                    {
                        countDestroyedFirstPlayer++;
                        availableShipsFirstPlayer--;
                        matrix[attackRow, attackCol] = 'X';
                    }
                    else if (AreValidCoordinates(matrix, attackRow, attackCol)
                        && matrix[attackRow, attackCol] == '>')
                    {
                        countDestroyedFirstPlayer++;
                        availableShipsSecondPlayer--;
                        matrix[attackRow, attackCol] = 'X';
                    }
                    else if (AreValidCoordinates(matrix, attackRow, attackCol)
                        && matrix[attackRow, attackCol] == '#')
                    {
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol) && matrix[attackRow + 1, attackCol] == '<')
                        {
                            availableShipsFirstPlayer--;
                            countDestroyedFirstPlayer++;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol) && matrix[attackRow - 1, attackCol] == '<')
                        {
                            availableShipsFirstPlayer--;
                            countDestroyedFirstPlayer++;
                            matrix[attackRow - 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow, attackCol - 1) && matrix[attackRow, attackCol - 1] == '<')
                        {
                            availableShipsFirstPlayer--;
                            countDestroyedFirstPlayer++;
                            matrix[attackRow, attackCol - 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow, attackCol + 1) && matrix[attackRow, attackCol + 1] == '<')
                        {
                            availableShipsFirstPlayer--;
                            countDestroyedFirstPlayer++;
                            matrix[attackRow, attackCol + 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol + 1) && matrix[attackRow + 1, attackCol + 1] == '<')
                        {
                            availableShipsFirstPlayer--;
                            countDestroyedFirstPlayer++;
                            matrix[attackRow + 1, attackCol + 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol - 1) && matrix[attackRow - 1, attackCol - 1] == '<')
                        {
                            availableShipsFirstPlayer--;
                            countDestroyedFirstPlayer++;
                            matrix[attackRow - 1, attackCol - 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol + 1) && matrix[attackRow - 1, attackCol + 1] == '<')
                        {
                            availableShipsFirstPlayer--;
                            countDestroyedFirstPlayer++;                            
                            matrix[attackRow - 1, attackCol + 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol - 1) && matrix[attackRow + 1, attackCol - 1] == '<')
                        {
                            availableShipsFirstPlayer--;
                            countDestroyedFirstPlayer++;
                            matrix[attackRow + 1, attackCol - 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol) && matrix[attackRow + 1, attackCol] == '>')
                        {
                            countDestroyedFirstPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol) && matrix[attackRow - 1, attackCol] == '>')
                        {
                            countDestroyedFirstPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow - 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow, attackCol - 1) && matrix[attackRow, attackCol - 1] == '>')
                        {
                            countDestroyedFirstPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow, attackCol - 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow, attackCol + 1) && matrix[attackRow, attackCol + 1] == '>')
                        {
                            countDestroyedFirstPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow, attackCol + 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol + 1) && matrix[attackRow + 1, attackCol + 1] == '>')
                        {
                            countDestroyedFirstPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol + 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol - 1) && matrix[attackRow - 1, attackCol - 1] == '>')
                        {
                            countDestroyedFirstPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow - 1, attackCol - 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol + 1) && matrix[attackRow - 1, attackCol + 1] == '>')
                        {
                            countDestroyedFirstPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow - 1, attackCol + 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol - 1) && matrix[attackRow + 1, attackCol - 1] == '>')
                        {
                            countDestroyedFirstPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol - 1] = 'X';
                        }
                    }
                }
                else
                {
                    if (AreValidCoordinates(matrix, attackRow, attackCol)
                        && matrix[attackRow, attackCol] == '<')
                    {
                        countDestroyedSecondPlayer++;
                        availableShipsFirstPlayer--;
                        matrix[attackRow, attackCol] = 'X';
                    }
                    else if (AreValidCoordinates(matrix, attackRow, attackCol)
                        && matrix[attackRow, attackCol] == '>')
                    {
                        countDestroyedSecondPlayer++;
                        availableShipsSecondPlayer--;
                        matrix[attackRow, attackCol] = 'X';
                    }
                    else if (AreValidCoordinates(matrix, attackRow, attackCol)
                        && matrix[attackRow, attackCol] == '#')
                    {
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol) && matrix[attackRow + 1, attackCol] == '<')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsFirstPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol) && matrix[attackRow - 1, attackCol] == '<')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsFirstPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow, attackCol - 1) && matrix[attackRow, attackCol - 1] == '<')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsFirstPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow, attackCol + 1) && matrix[attackRow, attackCol + 1] == '<')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsFirstPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol + 1) && matrix[attackRow + 1, attackCol + 1] == '<')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsFirstPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol - 1) && matrix[attackRow - 1, attackCol - 1] == '<')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsFirstPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol + 1) && matrix[attackRow - 1, attackCol + 1] == '<')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsFirstPlayer--;
                            matrix[attackRow - 1, attackCol + 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol - 1) && matrix[attackRow + 1, attackCol - 1] == '<')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsFirstPlayer--;
                            matrix[attackRow + 1, attackCol - 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol) && matrix[attackRow + 1, attackCol] == '>')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol) && matrix[attackRow - 1, attackCol] == '>')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow, attackCol - 1) && matrix[attackRow, attackCol - 1] == '>')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow, attackCol + 1) && matrix[attackRow, attackCol + 1] == '>')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol + 1) && matrix[attackRow + 1, attackCol + 1] == '>')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol - 1) && matrix[attackRow - 1, attackCol - 1] == '>')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow - 1, attackCol + 1) && matrix[attackRow - 1, attackCol + 1] == '>')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow - 1, attackCol + 1] = 'X';
                        }
                        if (AreValidCoordinates(matrix, attackRow + 1, attackCol - 1) && matrix[attackRow + 1, attackCol - 1] == '>')
                        {
                            countDestroyedSecondPlayer++;
                            availableShipsSecondPlayer--;
                            matrix[attackRow + 1, attackCol - 1] = 'X';
                        }
                    }
                }                
            }

            if (availableShipsSecondPlayer <= 0)
            {
                Console.WriteLine($"Player One has won the game! {countDestroyedFirstPlayer} ships have been sunk in the battle.");
            }
            else if (availableShipsFirstPlayer <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {countDestroyedSecondPlayer} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {availableShipsFirstPlayer} ships left. Player Two has {availableShipsSecondPlayer} ships left.");
            }
        }

        public static bool AreValidCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
