using System;

class FourMatrices
{
    static void Main()
    {
        Console.WriteLine("Matrix(n,n)");
        Console.Write("n = ");
        int size = int.Parse(Console.ReadLine());
        int cells = size * size;
        int[,] matrix = new int[size, size];

        int direction = 0;
        int count = 1;

        //first matrix
        /*
         * 1 5  9 13
         * 2 6 10 14
         * 3 7 11 15 
         * 4 8 12 16
         */
        for (int i = 0; i < size; i++)
        {
            for (int y = 0; y < size; y++)
            {
                matrix[y, i] = count++;
            }
        }
        PrintMatrix(size, matrix);

        //second matrix
        /*
         * 1 8  9 16
         * 2 7 10 15
         * 3 6 11 14 
         * 4 5 12 13
         */

        count = 1;
        for (int i = 0; i < size; i++) //columns
        {
            if (i % 2 == 0)
            {
                for (int y = 0; y < size; y++) //rows count down 
                {
                    matrix[y, i] = count++;
                }
            }
            else
            {
                for (int y = size - 1; y >= 0; y--) //rows count up
                {
                    matrix[y, i] = count++;
                }
            }
        }
        PrintMatrix(size, matrix);

        //third matrix
        /*
         * 7 11 14 16
         * 4  8 12 15
         * 2  5  9 13
         * 1  3  6 10
         */ 

        count = 1;
        int currentRow = size - 1;
        int currentCol = 0;
        int startRow = currentRow;
        int startCol = currentCol; 
        while (count <= cells)
        {
            while (currentCol < size && currentRow < size)
            {
                matrix[currentRow, currentCol] = count;
                count++;
                currentRow++;
                currentCol++;
            }
            
            if (startRow == 0)
            {
                startCol++;
            }
            else
            {
                startRow--;
            }
            currentCol = startCol;
            currentRow = startRow;
        }
        PrintMatrix(size, matrix);

        //fourth matrix
        /*
         * 1 12 11 10
         * 2 13 16  9
         * 3 14 15  8
         * 4  5  6  7
         */

        count = 1;
        currentCol = 0;
        currentRow = -1;
        int length = size;
        direction = 1;
        while (count <= cells)
        {
            for (int j = 0; j < length; j++)
            {
                currentRow = currentRow + direction;
                matrix[currentRow, currentCol] = count;
                count++;
            }
            length--;
 
            for (int k = 0; k < length; k++)
            {
                currentCol = currentCol + direction;
                matrix[currentRow, currentCol] = count;
                count++;
            }
            direction = direction * (-1);
        }
        PrintMatrix(size, matrix);
    }

    private static void PrintMatrix(int size, int[,] matrix)
    {
        Console.WriteLine();
        for (int i = 0; i < size; i++)
        {
            for (int y = 0; y < size; y++)
            {
                Console.Write("{0, 3}",matrix[i,y]);
            }
            Console.WriteLine();
        }
    }
}