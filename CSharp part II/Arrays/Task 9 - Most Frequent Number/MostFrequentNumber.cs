//Write a program that finds the most frequent number in an array. Example:
//      {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;

class MostFrequentNumber
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

        Array.Sort(numbers);

        int max = 1;
        int tempMax = 1;
        int value = numbers[0];

        for (int i = 1; i < size; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                tempMax = tempMax + 1;
            }

            if (numbers[i] != numbers[i - 1] || i == size - 1)
            {
                if (tempMax > max)
                {
                    max = tempMax;
                    value = numbers[i - 1];
                }
                tempMax = 1;
            }
        }

        Console.WriteLine("{0} ({1} times)", value, max);
    }
}
