using System;

class SequenceOfEquals
{
    public static string[,] matrix;

    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("M = ");
        int M = int.Parse(Console.ReadLine());

        matrix = new string[N, M];

        for (int i = 0; i < N; i++)
        {
            for (int y = 0; y < M; y++)
            {
                Console.Write("[{0},{1}] = ", i, y);
                matrix[i, y] = Console.ReadLine();
            }
        }
        
        /*
        int N = 5;
        int M = 4;
        matrix = new string[,]
        {
        {"ha","3","4","2"},
        {"3","ha","2","2"},
        {"8","2","ha","2"},
        {"2","5","9" ,"1"},
        {"7","1","0" ,"0"}
        };
        */

        int maxLength = 0;
        int tempLenght = 0;
        string pattern = "";

        for (int i = 0; i < N; i++)
        {
            for (int y = 0; y < M; y++)
            {
                tempLenght = FindMaxSequence(i, y, N, M);
                if (tempLenght > maxLength)
                {
                    maxLength = tempLenght;
                    pattern = matrix[i, y];
                }
            }
        }
        PrintMatrix(0, 0, N, M, matrix);
        Console.WriteLine();

        Console.WriteLine("pattern = [{0}], count = {1}", pattern, maxLength);
    }

    private static int FindMaxSequence(int row, int col, int rows, int cols)
    {
        int count = 0;
        int directionRow = 1;
        int directionCol = -2;
        int maxLenght = 0;
        int tempLenght = 0;
        int tempRow = 0;
        int tempCol = 0;

        while (count < 4)
        {
            tempLenght = 1;

            if (count < 3)
            {
                directionCol++;
            }
            else
            {
                directionRow = 0;
            }

            tempCol = col + directionCol;
            tempRow = row + directionRow;

            while (tempCol < cols && tempRow < rows && tempCol >=0)
            {
                if (matrix[tempRow, tempCol] == matrix[row,col])
                {
                    tempLenght++;
                }
                else
                {
                    break;
                }
                tempRow = tempRow + directionRow;
                tempCol = tempCol + directionCol;
            }
            if (tempLenght > maxLenght)
            {
                maxLenght = tempLenght;
            }
            count++;
        }
        return maxLenght;
    }

    private static void PrintMatrix(int row, int col, int rows, int cols, string[,] matrix)
    {
        Console.WriteLine();
        for (int i = row; i < rows; i++)
        {
            for (int y = col; y < cols; y++)
            {
                Console.Write("{0, 3}", matrix[i, y]);
            }
            Console.WriteLine();
        }
    }
}