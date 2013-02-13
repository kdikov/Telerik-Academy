using System;

class MinMaxAverageSumProduct
{
    static void Main()
    {
        int[] numbers = new int[] { 2, 5, 1};

        DrawLine();
        Console.WriteLine("Array: " + string.Join(", ",numbers));
        
        DrawLine();
        int minimum = numbers.Minimum();
        int minimumIndex = numbers.Minimum(index: true);

        Console.WriteLine("Smallest element in array: {0}",minimum);
        Console.WriteLine("Index of the first smallest element: {0}",minimumIndex);

        DrawLine();
        int maximal = numbers.Maximal();
        int maximalIndex = numbers.Maximal(index: true);

        Console.WriteLine("Largest element in array: {0}", maximal);
        Console.WriteLine("Index of the first largest element: {0}", maximalIndex);

        DrawLine();
        float average = numbers.Average();
        Console.WriteLine("Average in array: {0}", average);

        DrawLine();
        int sum = numbers.Sum();
        Console.WriteLine("Sum of all elements: {0}", sum);

        DrawLine();
        long product = numbers.Product();
        Console.WriteLine("Product of all elements: {0}", product);
    }

    private static void DrawLine()
    {
        Console.WriteLine("=======================================");
    }
}

public static class ArrayExtensions
{
    public static int Minimum(this int[] array, bool index = false) // if index = true, returns the index of first minimal value
    {
        int minimum = array[0];
        int minimumIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < minimum)
            {
                minimum = array[i];
                minimumIndex = i;
            }
        }
        if (index)
        {
            return minimumIndex;
        }
        else
        {
            return minimum;
        }
    }

    public static int Maximal(this int[] array, bool index = false) // if index = true, returns the index of first maximal value
    {
        int maximal = array[0];
        int maximalIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maximal)
            {
                maximal = array[i];
                maximalIndex = i;
            }
        }
        if (index)
        {
            return maximalIndex;
        }
        else
        {
            return maximal;
        }
    }

    public static float Average(this int[] array)
    {
        return array.Sum() / (float)array.Length;
    }

    public static int Sum(this int[] array)
    {
        int sum = 0;

        foreach (var number in array)
        {
            sum = sum + number;
        }

        return sum;
    }

    public static long Product(this int[] array)
    {
        long product = 1;

        foreach (var number in array)
        {
            product = product * number;
        }

        return product;
    }
}