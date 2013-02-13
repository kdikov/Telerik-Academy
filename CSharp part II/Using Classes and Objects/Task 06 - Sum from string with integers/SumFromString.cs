using System;

class SumFromString
{
    static void Main()
    {
        Console.Write("Enter set of numbers separated by space or comma: ");
        string input = Console.ReadLine();
        int[] numbers = input.ToIntArray();

        Console.WriteLine("Sum of all the numbers int the input is: {0}", ArraySum(numbers));
    }

    private static int ArraySum(int[] numbers)
    {
        int sum = 0;

        foreach (var number in numbers)
        {
            sum = sum + number;
        }
        return sum;
    }
}

public static class StringExtension
{
    public static int[] ToIntArray(this string input)
    { 
        string[] stringNumbers = input.Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[stringNumbers.Length];

        for (int i = 0; i < stringNumbers.Length; i++)
        {
            numbers[i] = int.Parse(stringNumbers[i]);
        }

        return numbers;
    }

}