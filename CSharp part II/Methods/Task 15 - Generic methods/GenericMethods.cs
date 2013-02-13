using System;

class GenericMethods
{
    static void Main()
    {
        //int[] numbers = new int[] { 2, 5, 1, 1 };
        //long[] numbers = new long[] { 2, 5, 1, 1 };
        //float[] numbers = new float[] { 2.1f, 5.3f, 1.01f, 1.02f };
        double[] numbers = new double[] { 2.1, 5.3, 1.01, 1.02 };

        DrawLine();
        Console.WriteLine("Array: " + string.Join(", ", numbers));

        DrawLine();
        dynamic minimum = numbers.Minimum();
        Console.WriteLine("Smallest element in array: {0}", minimum);

        DrawLine();
        dynamic maximal = numbers.Maximal();
        Console.WriteLine("Largest element in array: {0}", maximal);

        DrawLine();
        double average = numbers.Average();
        Console.WriteLine("Average in array: {0}", average);

        DrawLine();
        dynamic sum = numbers.Sum();
        Console.WriteLine("Sum of all elements: {0}", sum);

        DrawLine();
        dynamic product = numbers.Product();
        Console.WriteLine("Product of all elements: {0}", product);
    }

    private static void DrawLine()
    {
        Console.WriteLine("=======================================");
    }
}

public static class ArrayExtensions
{
    public static T Minimum<T>(this T[] array)
    {
        dynamic minimum = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < minimum)
            {
                minimum = array[i];
            }
        }
        return minimum;
    }

    public static T Maximal<T>(this T[] array)
    {
        dynamic maximal = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maximal)
            {
                maximal = array[i];
            }
        }
        return maximal;
    }

    public static double Average<T>(this T[] array) 
    {
        dynamic sum = 0;
        foreach (var number in array)
        {
            sum = sum + number;
        }
        return sum / (double)array.Length;
    }

    public static T Sum<T>(this T[] array)
    {
        dynamic sum = 0;
        foreach (var number in array)
        {
            sum = sum + number;
        }
        return sum;
    }

    public static T Product<T>(this T[] array)
    {
        dynamic product = 1;
        foreach (var number in array)
        {
            product = product * number;
        }

        return product;
    }
}