/*
 * 18.Write a program that reads an array of integers and removes 
 * from it a minimal number of elements in such way that the remaining 
 * array is sorted in increasing order. Print the remaining sorted array. 
 * Example:
 * {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}
 */
using System;

class LongestSortedSubset
{
    public static int neededSubset = 0;
    public static int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };

    public static void PopulateList(int arraySize, int currentPosition, int subsetLength, int currentCount, int currentNumber)
    {
        if (neededSubset == 0)
        {
            if (currentCount == subsetLength - 1)
            {
                for (int i = currentPosition; i < arraySize; i++)
                {
                    IsSorted(currentNumber | (1 << i), arraySize);
                }
            }
            else if (currentCount < subsetLength - 1)
            {
                currentCount++;
                for (int i = currentPosition; i < arraySize; i++)
                {
                    PopulateList(arraySize, i + 1, subsetLength, currentCount, currentNumber | (1 << i));
                }
            }
        }
    }

    public static void IsSorted(int currentNumber, int arraySize)
    {
        int lastNumber = int.MinValue;
        bool sorted = true;
        for (int i = 0; i < arraySize; i++)
        {
            if ((currentNumber >> i & 1) == 1)
            {
                if (array[i] < lastNumber)
                {
                    sorted = false;
                    break;
                }
                else
                {
                    lastNumber = array[i];
                }
            }
        }
        if (sorted)
        {
            neededSubset = currentNumber;
        }
    }

    static void Main()
    {
        int arraySize = array.Length;

        for (int i = arraySize - 1; i > 0; i--)
        {
			//PopulateList(int arraySize, int currentPosition, int subsetLength, int currentCount, int currentNumber)
            PopulateList(arraySize, 0, i, 0, 0);
            if (neededSubset != 0)
            {
                break;
            }
        }

        Console.Write("{");
        for (int i = 0; i < arraySize; i++)
        {
            if ((neededSubset >> i & 1) == 1)
            {
                Console.Write("{0}, ", array[i]);
            }
        }
        Console.WriteLine("\b\b}");
    }
}
