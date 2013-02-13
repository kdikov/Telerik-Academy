/*
Write a program that finds the sequence of maximal sum in given array. Example:
{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  ->  {2, -1, 6, 4}
Can you do it with only one loop (with single scan through the elements of the array)?
*/
using System;

class SequenceOfMaxSum
{
    static void Main()
    {
        Console.Write("Array size: ");
        int size = int.Parse(Console.ReadLine());

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("number [{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int startIndex = 0;
        int endIndex = 0;
        int tempStartIndex = 0;
        int maxSum = int.MinValue;
        int tempSum = 0;

        for (int i = 0; i < size; i++)
        {
            tempSum = tempSum + numbers[i];

            if (tempSum > maxSum)
            {
                maxSum = tempSum;
                startIndex = tempStartIndex;
                endIndex = i;
            }
            if (tempSum < 0)
            {
                tempSum = 0;
                tempStartIndex = i + 1;
            }
        }

        Console.Write("{");
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(numbers[i] + ((i < endIndex) ? ", " : ""));
        }
        Console.WriteLine("}");
    }
}