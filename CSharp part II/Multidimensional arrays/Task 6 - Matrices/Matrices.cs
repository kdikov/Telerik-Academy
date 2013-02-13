using System;

class Matrix
{
    public int rows;
    public int cols;
    public int[,] matrix;

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        matrix = new int[rows, cols];
    }

    public int this[int rows, int cols]
    {
        get 
        {
            return matrix[rows, cols];
        }
        set 
        {
            matrix[rows, cols] = value;
        }
    }

    public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix newMatrix = new Matrix(firstMatrix.rows, firstMatrix.cols);

        for (int row = 0; row < newMatrix.rows; row++)
        {
            for (int col = 0; col < newMatrix.cols; col++)
            {
                newMatrix[row, col] = firstMatrix[row, col] + secondMatrix[row, col];
            }
        }
        return newMatrix;
    }

    public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix newMatrix = new Matrix(firstMatrix.rows, firstMatrix.cols);

        for (int row = 0; row < newMatrix.rows; row++)
        {
            for (int col = 0; col < newMatrix.cols; col++)
            {
                newMatrix[row, col] = firstMatrix[row, col] - secondMatrix[row, col];
            }
        }
        return newMatrix;
    }


    public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
    {
        if (firstMatrix.cols != secondMatrix.rows)
        {
            throw new FormatException("Number of columns in the first matrix must be equal to the number of rows of the second matrix");
        }

        Matrix newMatrix = new Matrix(firstMatrix.rows, firstMatrix.cols);
        
        for (int row = 0; row < firstMatrix.rows; row++)
        {
            for (int col = 0; col < secondMatrix.cols; col++)
            {
                for (int fmcol = 0; fmcol < firstMatrix.cols; fmcol++)
                {
                    newMatrix[row, col] = newMatrix[row, col] + firstMatrix[row, fmcol] * secondMatrix[fmcol, col];
                }
            }
        }

        return newMatrix;
    }

    public override string ToString()
    {
        string newString = "";
        int max = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int y = 0; y < cols; y++)
            {
                if (matrix[i,y] > max)
                {
                    max = matrix[i, y];  
                }
            }
        }

        int maxLenght = max.ToString().Length + 2;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                newString = newString + matrix[row, col].ToString().PadRight(maxLenght);
            }

            if (row != rows - 1 && cols != cols - 1)
            {
                newString = newString + "\n";
            } 
        }
        return newString;
    }
}

class Matrices
{
    static void Main()
    {
        Console.Write("Number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        Matrix matrix1 = new Matrix(rows, cols);
        Matrix matrix2 = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int y = 0; y < cols; y++)
            {
                Console.Write("Matrix1[{0},{1}] = ", i, y);
                matrix1[i, y] = int.Parse(Console.ReadLine());
            }   
        }

        for (int i = 0; i < rows; i++)
        {
            for (int y = 0; y < cols; y++)
            {
                Console.Write("Matrix2[{0},{1}] = ", i, y);
                matrix2[i, y] = int.Parse(Console.ReadLine());
            }
        }

        Matrix result = new Matrix(matrix1.rows, matrix1.cols);


        Console.WriteLine("First matrix");
        Console.WriteLine(matrix1);
        Console.WriteLine();
        Console.WriteLine("Second matrix");
        Console.WriteLine(matrix2);
        Console.WriteLine();

        Console.WriteLine("Adding");
        result = matrix1 + matrix2;
        Console.WriteLine(result);
        Console.WriteLine();

        Console.WriteLine("Subtracting");
        result = matrix1 - matrix2;
        Console.WriteLine(result);
        Console.WriteLine();

        Console.WriteLine("Multiplying");
        result = matrix1 * matrix2;
        Console.WriteLine(result);
        Console.WriteLine();
    }
}