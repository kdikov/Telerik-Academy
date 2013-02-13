/* 4.Write a program that finds the maximal sequence 
 * of equal elements in an array.
 * Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
 */

using System;

class MaxSequenceOfEquals
{
    static void Main()
    {
        Console.Write("Array size: ");
        int size = int.Parse(Console.ReadLine());

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("[{0}] element = ",i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int max = 1;
        int tempMax = 1;
        int value = numbers[0];

        for (int i = 1; i < size; i++)
        {
            if (numbers[i] == numbers[i-1])
            {
                tempMax = tempMax + 1;
            }
            
            if (numbers[i] != numbers[i-1] || i == size - 1)
            {
                if (tempMax > max)
                {
                    max = tempMax;
                    value = numbers[i-1];
                }
                tempMax = 1;
            }
        }

        Console.Write("{");
        for (int i = 0; i < max; i++)
        {
            Console.Write(value + (i < max-1?", ":""));
        }
        Console.WriteLine("}");
    }
}