using System;

class SubmatrixMaxSum
{
    public static int[,] matrix;
    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("M = ");
        int M = int.Parse(Console.ReadLine());
        
        matrix = new int[N, M];

        for (int i = 0; i < N; i++)
        {
            for (int y = 0; y < M; y++)
            {
                Console.Write("[{0},{1}] = ", i, y);
                matrix[i, y] = int.Parse(Console.ReadLine());
            }
        }

        /*
        int N = 5;
        int M = 4;
        matrix = new int[,]
         * {
         * {2,3,4,2},
         * {3,2,6,2},
         * {8,5,3,8},
         * {1,5,9,9},
         * {7,1,0,0}
         * }; 
        */

        int maxSum = 0;
        int tempSum = 0;
        int maxSumRow = 0;
        int maxSumCol = 0;

        for (int i = 0; i <= N - 3; i++)
        {
            for (int y = 0; y <= M - 3; y++)
            {
                tempSum = CalculateSum(i, y);
                if(tempSum > maxSum)
                {
                    maxSum = tempSum;
                    maxSumRow = i;
                    maxSumCol = y;
                }
            }
        }

        PrintMatrix(0, 0, N, M, matrix);
        PrintMatrix(maxSumRow, maxSumCol, maxSumRow + 3, maxSumCol + 3, matrix);
        Console.WriteLine();
        Console.WriteLine("Max sum = " + maxSum);
    }

    private static int CalculateSum(int row, int col)
    {
        int sum = 0;

        for (int i = row; i < row + 3; i++)
        {
            for (int y = col; y < col + 3; y++)
            {
                sum = sum + matrix[i, y];
            }   
        }
        return sum;
    }

    private static void PrintMatrix(int row, int col, int rows, int cols, int[,] matrix)
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