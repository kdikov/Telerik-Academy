/*
 * 17. * Write a program that reads three integer numbers N, K and S
 * and an array of N elements from the console.
 * Find in the array a subset of K elements that have sum S or indicate about its absence.
 */
using System;
using System.Collections.Generic;

class SubsetSumFixedLength
{
    public static List<long> subsetList = new List<long>();

    private static void PopulateList(long arraySize, int currentPosition, int subsetLength, int currentCount, long currentNumber)
    {
        if (currentCount == subsetLength - 1)
        {
            for (int i = currentPosition; i < arraySize; i++)
            {
                subsetList.Add(currentNumber | (1L << i));
            }
        }
        else if (currentCount < subsetLength - 1)
        {
            currentCount++;
            for (int i = currentPosition; i < arraySize; i++)
            {
                PopulateList(arraySize, i + 1, subsetLength, currentCount, currentNumber | (1L << i));
            }
        }
    }

    static void Main()
    {
        int[] array = { 1, 3, 2, 9, 4, -1, -5, 1, 8, 32, 10, 13, 3, 7, 1, 3 };
        int searchedSum = 55;
        int subsetLength = 5;
        int arraySize = array.Length;

        long neededSubset = 0;
        int tempSum = 0;
        int tempCount = 0;

        PopulateList(arraySize, 0, subsetLength, 0, 0); // finding all subsets with exactly "subsetLenght" number of ones (binary)

        foreach (long currentNumber in subsetList)
        {
            for (int y = 0; y < arraySize; y++)
            {
                if ((currentNumber >> y & 1) == 1)
                {
                    tempSum = tempSum + array[y];
                    tempCount++;
                    if (tempCount == subsetLength)
                    {
                        if (tempSum == searchedSum)
                        {
                            neededSubset = currentNumber;
                        }
                        break;
                    }
                }
            }

            if (neededSubset != 0)
            {
                break;
            }
            tempSum = 0;
            tempCount = 0;
        }

        if (neededSubset == 0)
        {
            Console.WriteLine("No such subset");
        }
        else
        {
            Console.Write("yes {");
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
}
