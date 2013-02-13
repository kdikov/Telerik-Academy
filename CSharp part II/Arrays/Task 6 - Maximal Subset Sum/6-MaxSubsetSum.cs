/* 
 * 6.Write a program that reads two integer numbers N and K 
 * and an array of N elements from the console. 
 * Find in the array those K elements that have maximal sum.
 */

using System;

class MaxSubsetSum
{
    static void Main()
    {
        Console.Write("Array size: ");
        int size = int.Parse(Console.ReadLine());
        Console.Write("Array size: ");
        int K = int.Parse(Console.ReadLine());

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("number [{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = int.MinValue;
        int tempSum = 0;
        int startIndex = 0;

        for (int i = 0; i <= size - K; i++)
        {
            for (int y = i; y < i + K; y++)
            {
                tempSum = tempSum + numbers[y];
            }

            if (tempSum > maxSum)
            {
                maxSum = tempSum;
                startIndex = i;
            }
            tempSum = 0;
        }

        Console.Write("{");
        for (int i = startIndex; i < startIndex + K; i++)
        {
            Console.Write(numbers[i] + ((i < startIndex + K - 1) ? ", " : ""));
        }
        Console.WriteLine("}");
    }
}