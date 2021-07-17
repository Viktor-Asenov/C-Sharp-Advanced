using System;

namespace _02._Super_Mario
{
    public class Program
    {
        static void Main(string[] args)
        {
            int marioLive = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            int marioCurrentPositionRow = marioRow;
            int marioCurrentPositionCol = marioCol;
            int marioOldPositionRow = 0;
            int marioOldPositionCol = 0;

            while (true)
            {
                string[] currentCoordinates = Console.ReadLine().Split();
                char marioDirection = char.Parse(currentCoordinates[0]);
                int enemyRowCoordinate = int.Parse(currentCoordinates[1]);
                int enemyColCoordinate = int.Parse(currentCoordinates[2]);

                matrix[enemyRowCoordinate, enemyColCoordinate] = 'B';
                if (marioDirection == 'W')
                {
                    if (IsInside(matrix, marioCurrentPositionRow - 1, marioCurrentPositionCol))
                    {
                        marioOldPositionRow = marioCurrentPositionRow;
                        marioOldPositionCol = marioCurrentPositionCol;
                        if (matrix[marioCurrentPositionRow - 1, marioCurrentPositionCol] == 'B'
                            && marioLive >= 2)
                        {
                            marioCurrentPositionRow -= 1;
                            marioLive -= 2;
                        }
                        else if (matrix[marioCurrentPositionRow - 1, marioCurrentPositionCol] == '-')
                        {
                            matrix[marioOldPositionRow, marioOldPositionCol] = '-';
                            marioCurrentPositionRow -= 1;
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol] = 'M';
                        }
                        else if (matrix[marioCurrentPositionRow - 1, marioCurrentPositionCol] == 'P')
                        {
                            marioLive--;
                            matrix[marioOldPositionRow, marioOldPositionCol] = '-';
                            matrix[marioCurrentPositionRow - 1, marioCurrentPositionCol] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLive}");
                            break;
                        }
                        else
                        {
                            matrix[marioCurrentPositionRow - 1, marioCurrentPositionCol] = 'X';
                            break;
                        }                        
                    }                    
                }
                else if (marioDirection == 'S')
                {
                    if (IsInside(matrix, marioCurrentPositionRow + 1, marioCurrentPositionCol))
                    {
                        marioOldPositionRow = marioCurrentPositionRow;
                        marioOldPositionCol = marioCurrentPositionCol;
                        if (matrix[marioCurrentPositionRow + 1, marioCurrentPositionCol] == 'B'
                            && marioLive >= 2)
                        {
                            marioCurrentPositionRow += 1;
                            marioLive -= 2;
                        }
                        else if (matrix[marioCurrentPositionRow + 1, marioCurrentPositionCol] == '-')
                        {
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol] = '-';
                            marioCurrentPositionRow += 1;
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol] = 'M';
                        }
                        else if (matrix[marioCurrentPositionRow + 1, marioCurrentPositionCol] == 'P')
                        {
                            marioLive--;
                            matrix[marioOldPositionRow, marioOldPositionCol] = '-';
                            matrix[marioCurrentPositionRow + 1, marioCurrentPositionCol] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLive}");
                            break;
                        }
                        else
                        {
                            matrix[marioCurrentPositionRow + 1, marioCurrentPositionCol] = 'X';
                            break;
                        }
                    }
                }
                else if (marioDirection == 'A')
                {
                    if (IsInside(matrix, marioCurrentPositionRow, marioCurrentPositionCol - 1))
                    {
                        marioOldPositionRow = marioCurrentPositionRow;
                        marioOldPositionCol = marioCurrentPositionCol;
                        if (matrix[marioCurrentPositionRow, marioCurrentPositionCol - 1] == 'B'
                            && marioLive >= 2)
                        {
                            marioCurrentPositionCol -= 1;
                            marioLive -= 2;
                        }
                        else if (matrix[marioCurrentPositionRow, marioCurrentPositionCol - 1] == '-')
                        {
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol] = '-';
                            marioCurrentPositionCol -= 1;
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol] = 'M';
                        }
                        else if (matrix[marioCurrentPositionRow, marioCurrentPositionCol - 1] == 'P')
                        {
                            marioLive--;
                            matrix[marioOldPositionRow, marioOldPositionCol] = '-';
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol - 1] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLive}");
                            break;
                        }
                        else
                        {
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol - 1] = 'X';
                            break;
                        }
                    }
                }
                else if (marioDirection == 'D')
                {
                    if (IsInside(matrix, marioCurrentPositionRow, marioCurrentPositionCol + 1))
                    {
                        marioOldPositionRow = marioCurrentPositionRow;
                        marioOldPositionCol = marioCurrentPositionCol;
                        if (matrix[marioCurrentPositionRow, marioCurrentPositionCol + 1] == 'B'
                            && marioLive >= 2)
                        {
                            marioCurrentPositionCol += 1;
                            marioLive -= 2;
                        }
                        else if (matrix[marioCurrentPositionRow, marioCurrentPositionCol + 1] == '-')
                        {
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol] = '-';
                            marioCurrentPositionCol += 1;
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol] = 'M';
                        }
                        else if (matrix[marioCurrentPositionRow, marioCurrentPositionCol + 1] == 'P')
                        {
                            marioLive--;
                            matrix[marioOldPositionRow, marioOldPositionCol] = '-';
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol + 1] = '-';
                            Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLive}");
                            break;
                        }
                        else
                        {
                            matrix[marioCurrentPositionRow, marioCurrentPositionCol + 1] = 'X';
                            break;
                        }
                    }
                }

                marioLive--;
                if (marioLive <= 0)
                {                    
                    matrix[marioCurrentPositionRow, marioCurrentPositionCol] = 'X';
                    matrix[marioOldPositionRow, marioOldPositionCol] = '-';
                    Console.WriteLine($"Mario died at {marioCurrentPositionRow};{marioCurrentPositionCol}.");
                    PrintMatrix(matrix);
                    return;
                }
            }

            PrintMatrix(matrix);
        }

        public static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        public static void PrintMatrix(char[,] matrix)
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
