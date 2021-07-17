using System;

namespace Other
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLive = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                matrix[row] = new char[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = rowData[col];
                    if (matrix[row][ col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            matrix[marioRow][ marioCol] = '-';
            while (true)
            {
                string[] currentCoordinates = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                char marioDirection = char.Parse(currentCoordinates[0]);
                int enemyRowCoordinate = int.Parse(currentCoordinates[1]);
                int enemyColCoordinate = int.Parse(currentCoordinates[2]);

                matrix[enemyRowCoordinate][enemyColCoordinate] = 'B';
                if (marioDirection == 'W')
                {
                    marioRow--;
                }
                else if (marioDirection == 'S')
                {
                    marioRow++;
                }
                else if (marioDirection == 'A')
                {
                    marioCol--;
                }
                else if (marioDirection == 'D')
                {
                    marioCol++;
                }

                if (!CanMove(matrix, marioRow, marioCol))
                {
                    if (marioDirection == 'W')
                    {
                        marioRow++;
                    }
                    else if (marioDirection == 'S')
                    {
                        marioRow--;
                    }
                    else if (marioDirection == 'A')
                    {
                        marioCol++;
                    }
                    else if (marioDirection == 'D')
                    {
                        marioCol--;
                    }

                    marioLive--;
                    if (marioLive <= 0)
                    {
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        matrix[marioRow][marioCol] = 'X';
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (matrix[marioRow][marioCol] == 'P')
                {
                    matrix[marioRow][marioCol] = '-';
                    marioLive--;
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLive}");
                    break;
                }
                else if (matrix[marioRow][marioCol] == 'B')
                {
                    marioLive -= 2;
                }

                matrix[marioRow][marioCol] = '-';
                marioLive--;

                if (marioLive <= 0)
                {
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    matrix[marioRow][marioCol] = 'X';
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        public static bool CanMove (char[][] matrix, int row, int col)
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
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
