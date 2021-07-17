using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
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

            int countSunkShipsFirstPlayer = 0;
            int countSunkShipsSecondPlayer = 0;
            for (int i = 0; i < attackCoordinates.Count; i++)
            {
                int attackRow = attackCoordinates[i][0];
                int attackCol = attackCoordinates[i][1];
                int sunkenShips = 0;

                if (i % 2 == 0)
                {                    
                    if (AreValidCoordinates(matrix, attackRow, attackCol))
                    {
                        if (matrix[attackRow, attackCol] == '<')
                        {
                            availableShipsFirstPlayer--;
                            if (availableShipsFirstPlayer <= 0)
                            {
                                break;
                            }

                            matrix[attackRow, attackCol] = 'X';
                        }
                        else if (matrix[attackRow, attackCol] == '>')
                        {
                            countSunkShipsFirstPlayer++;
                            availableShipsSecondPlayer--;
                            if (availableShipsSecondPlayer <= 0)
                            {
                                break;
                            }

                            matrix[attackRow, attackCol] = 'X';
                        }
                        else if (matrix[attackRow, attackCol] == '#')
                        {
                            sunkenShips = GetAllDestroyedShipsFirstPlayer(matrix, attackRow, attackCol, availableShipsFirstPlayer);
                            countSunkShipsFirstPlayer += sunkenShips;                                
                            availableShipsSecondPlayer -= sunkenShips;
                            if (availableShipsSecondPlayer <= 0)
                            {
                                break;
                            }

                            matrix[attackRow, attackCol] = 'X';
                        }
                    }
                }
                else
                {
                    if (AreValidCoordinates(matrix, attackRow, attackCol))
                    {
                        if (matrix[attackRow, attackCol] == '<')
                        {
                            availableShipsFirstPlayer--;
                            if (availableShipsFirstPlayer <= 0)
                            {
                                break;
                            }

                            matrix[attackRow, attackCol] = 'X';
                        }
                        else if (matrix[attackRow, attackCol] == '>')
                        {
                            countSunkShipsSecondPlayer++;
                            availableShipsSecondPlayer--;
                            if (availableShipsSecondPlayer <= 0)
                            {
                                break;
                            }

                            matrix[attackRow, attackCol] = 'X';
                        }
                        else if (matrix[attackRow, attackCol] == '#')
                        {
                            sunkenShips = GetAllDestroyedShipsSecondPlayer(matrix, attackRow, attackCol, availableShipsSecondPlayer);
                            countSunkShipsSecondPlayer += sunkenShips;
                            availableShipsFirstPlayer -= sunkenShips;
                            if (availableShipsFirstPlayer <= 0)
                            {
                                break;
                            }

                            matrix[attackRow, attackCol] = 'X';
                        }
                    }
                }
            }

            if (availableShipsSecondPlayer <= 0)
            {
                Console.WriteLine($"Player One has won the game! {countSunkShipsFirstPlayer} ships have been sunk in the battle.");
            }
            else if (availableShipsFirstPlayer <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {countSunkShipsSecondPlayer} ships have been sunk in the battle.");
            }
            else
            {

            }
        }

        public static bool AreValidCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        public static int GetAllDestroyedShipsFirstPlayer(char[,] matrix, int row, int col, int availableShips)
        {
            int countDestroyed = 0;
            if (AreValidCoordinates(matrix, row + 1, col) && matrix[row + 1, col] == '<')
            {
                availableShips--;
                countDestroyed++;
                matrix[row + 1, col] = 'X';
            }
            if (AreValidCoordinates(matrix, row - 1, col) && matrix[row - 1, col] == '<')
            {
                availableShips--;
                countDestroyed++;
                matrix[row - 1, col] = 'X';
            }
            if (AreValidCoordinates(matrix, row, col - 1) && matrix[row, col - 1] == '<')
            {
                availableShips--;
                countDestroyed++;
                matrix[row, col - 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row, col + 1) && matrix[row, col + 1] == '<')
            {
                availableShips--;
                countDestroyed++;
                matrix[row, col + 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] == '<')
            {
                availableShips--;
                countDestroyed++;
                matrix[row + 1, col + 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] == '<')
            {
                availableShips--;
                countDestroyed++;
                matrix[row - 1, col - 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row + 1, col) && matrix[row + 1, col] == '>')
            {
                countDestroyed++;
                matrix[row + 1, col] = 'X';
            }
            if (AreValidCoordinates(matrix, row - 1, col) && matrix[row - 1, col] == '>')
            {
                countDestroyed++;
                matrix[row - 1, col] = 'X';
            }
            if (AreValidCoordinates(matrix, row, col - 1) && matrix[row, col - 1] == '>')
            {
                countDestroyed++;
                matrix[row, col - 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row, col + 1) && matrix[row, col + 1] == '>')
            {
                countDestroyed++;
                matrix[row, col + 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] == '>')
            {
                countDestroyed++;
                matrix[row + 1, col + 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] == '>')
            {
                countDestroyed++;
                matrix[row - 1, col - 1] = 'X';
            }

            return countDestroyed;
        }

        public static int GetAllDestroyedShipsSecondPlayer(char[,] matrix, int row, int col, int availableShips)
        {
            int countDestroyed = 0;
            if (AreValidCoordinates(matrix, row + 1, col) && matrix[row + 1, col] == '<')
            {
                countDestroyed++;
                matrix[row + 1, col] = 'X';
            }
            if (AreValidCoordinates(matrix, row - 1, col) && matrix[row - 1, col] == '<')
            {
                countDestroyed++;
                matrix[row - 1, col] = 'X';
            }
            if (AreValidCoordinates(matrix, row, col - 1) && matrix[row, col - 1] == '<')
            {
                countDestroyed++;
                matrix[row, col - 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row, col + 1) && matrix[row, col + 1] == '<')
            {
                countDestroyed++;
                matrix[row, col + 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] == '<')
            {
                countDestroyed++;
                matrix[row + 1, col + 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] == '<')
            {
                countDestroyed++;
                matrix[row - 1, col - 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row + 1, col) && matrix[row + 1, col] == '>')
            {
                availableShips--;
                countDestroyed++;
                matrix[row + 1, col] = 'X';
            }
            if (AreValidCoordinates(matrix, row - 1, col) && matrix[row - 1, col] == '>')
            {
                availableShips--;
                countDestroyed++;
                matrix[row - 1, col] = 'X';
            }
            if (AreValidCoordinates(matrix, row, col - 1) && matrix[row, col - 1] == '>')
            {
                availableShips--;
                countDestroyed++;
                matrix[row, col - 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row, col + 1) && matrix[row, col + 1] == '>')
            {
                availableShips--;
                countDestroyed++;
                matrix[row, col + 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] == '>')
            {
                availableShips--;
                countDestroyed++;
                matrix[row + 1, col + 1] = 'X';
            }
            if (AreValidCoordinates(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] == '>')
            {
                availableShips--;
                countDestroyed++;
                matrix[row - 1, col - 1] = 'X';
            }

            return countDestroyed;
        }

        public static void PrintMatrix(char[,] matrix)
        {
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
}
