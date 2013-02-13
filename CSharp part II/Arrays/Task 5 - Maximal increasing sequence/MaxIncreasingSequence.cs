/*
5.Write a program that finds the maximal increasing sequence in an array.
Example:  {3, 2, 3, 4, 2, 2, 4} ->{2, 3, 4}.
*/

using System;

class MaxIncreasingSequence
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

        int bestStartPosition = 0;
        int currentStartPosition = 0;
        int maxLength = 1;
        int tempLength = 1;

        for (int currentPositon = 1; currentPositon < size; currentPositon++)
        {
            if (numbers[currentPositon] > numbers[currentPositon - 1])
            {
                tempLength = tempLength + 1;
            }

            if (numbers[currentPositon] <= numbers[currentPositon - 1] || currentPositon == size - 1)
            {
                if (tempLength > maxLength)
                {
                    bestStartPosition = currentStartPosition;
                    maxLength = tempLength;
                }

                tempLength = 1;
                currentStartPosition = currentPositon;
            }
        }

        Console.Write("{");
        for (int i = 0; i < maxLength; i++)
        {
            Console.Write(numbers[i + bestStartPosition] + ((i < maxLength - 1) ? ", " : ""));
        }
        Console.WriteLine("}");
    }
}
