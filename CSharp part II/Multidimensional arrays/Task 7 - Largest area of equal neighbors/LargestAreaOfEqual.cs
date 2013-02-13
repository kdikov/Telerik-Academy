/*
 * Write a program that finds the largest area of equal 
 * neighbor elements in a rectangular matrix and prints its size.
*/

using System;

class LargestAreaOfEqual
{
    public static int[,] matrix;
    public static bool[,] usedElements;
    public static int largestArea = 0;
    public static int tempAreaSize;
    public static int N;
    public static int M;
    public static int pattern;

    static void Main()
    {
        /*
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
        */
        
        N = 5;
        M = 5;
        int element = 0;

        matrix = new int[,]
        {
        {3,0,4,2,2},
        {3,0,2,2,2},
        {0,0,0,8,8},
        {0,3,0,0,9},
        {7,1,2,0,0}
        }; 

        usedElements = new bool[N,M];

        for (int i = 0; i < N; i++)
        {
            for (int y = 0; y < M; y++)
            {
                if (usedElements[i, y] == false) // no need to check used elements
                {
                    tempAreaSize = 1;
                    pattern = matrix[i, y];
                    FindArea(i, y);
                    if (tempAreaSize > largestArea)
                    {
                        largestArea = tempAreaSize;
                        element = pattern;
                    }
                }
            }
        }

        Console.WriteLine("Element [{0}], area size = {1}", element, largestArea);
    }

    private static void FindArea(int row, int col)
    {
        //neighbours
        int[] neighRow = new int[] { -1, 1, 0, 0 };
        int[] neighCol = new int[] {  0, 0, 1, -1 };
        //

        usedElements[row, col] = true; //mark cell as checked

        for (int i = 0; i < 4; i++)
        {
            if ( row + neighRow[i] >= 0  &&
                 row + neighRow[i] < N   &&
                 col + neighCol[i] >= 0  &&
                 col + neighCol[i] < M) //check if neighbour is in boundaries
            {
                if (matrix[row + neighRow[i], col + neighCol[i]] == pattern &&
                    usedElements[row + neighRow[i], col + neighCol[i]] == false) //check if equals and not checked 
                {
                    tempAreaSize++;
                    FindArea(row + neighRow[i], col + neighCol[i]);
                }
            }
        }
    }
}