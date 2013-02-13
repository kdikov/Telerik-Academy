/*
10.Write a program that finds in given array of integers a sequence of given sum S (if present).
Example:  {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5} 
*/
using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        Console.Write("Array size: ");
        int size = int.Parse(Console.ReadLine());
        Console.Write("S = ");
        int S = int.Parse(Console.ReadLine());

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("number [{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int tempSum = 0;
        int startIndex = 0;
        int endIndex = 0;
        bool breaker = false;
        for (int i = 0; i < size; i++)
        {
            for (int y = i; y < size; y++)
            {
                tempSum = tempSum + numbers[y];

                if (tempSum == S)
                {
                    startIndex = i;
                    endIndex = y;
                    breaker = true;
                    break;
                }
            }
            
            if (breaker)
            {
                break;
            }

            tempSum = 0;
        }

        Console.Write("{");
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(numbers[i] + ((i < endIndex) ? ", " : ""));
        }
        Console.WriteLine("}");
    }
}