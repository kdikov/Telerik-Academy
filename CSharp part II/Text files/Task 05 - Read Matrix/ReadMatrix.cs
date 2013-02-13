//Write a program that reads a text file containing a square matrix 
//of numbers and finds in the matrix an area of size 2x2 with
//a maximal sum of its elements. The first line in the input file contains 
//the size of matrix N. Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file.

using System;
using System.IO;
using System.Diagnostics;

class ReadMatrix
{
    public static int[,] matrix;
    static void Main()
    {
        int N = new int();

        using (StreamReader matrixFile = new StreamReader("matrix.txt"))
        {
            N = int.Parse(matrixFile.ReadLine());
            matrix = new int[N, N];
            string[] line = null;
            for (int i = 0; i < N; i++)
            {
                line = matrixFile.ReadLine().Split(' ');
                for (int y = 0; y < N; y++)
                {
                    matrix[i, y] = int.Parse(line[y]);
                }
            }
        }

        int maxSum = 0;
        int tempSum = 0;
        int maxSumRow = 0;
        int maxSumCol = 0;

        for (int i = 0; i <= N - 2; i++)
        {
            for (int y = 0; y <= N - 2; y++)
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

        using (StreamWriter output = new StreamWriter("result.txt"))
        {
            output.WriteLine(maxSum);
        }

        Console.Write("Open result.txt? (y/n): ");
        string yesNo = Console.ReadLine();

        switch (yesNo)
        {
            case "y":
                Process.Start("result.txt");
                break;
            default:
                Console.WriteLine("Good bye");
                break;
        }
    }

    private static int CalculateSum(int row, int col)
    {
        int sum = 0;

        for (int i = row; i < row + 2; i++)
        {
            for (int y = col; y < col + 2; y++)
            {
                sum = sum + matrix[i, y];
            }   
        }
        return sum;
    }
}
