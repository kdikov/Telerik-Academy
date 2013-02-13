/*
 *  16.* We are given an array of integers and a number S.
 *  Write a program to find if there exists a subset of the
 *  elements of the array that has a sum S.
 *  Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)
 */
using System;

class SubsetSum
{
    static void Main()
    {
        int[] array = { 29, 11, 2, 4, 3, 5, 2, 6, 4, 2, 1, 52, 2, 3, 2, 5, 24, 12, 32, 1, -4, -2, -5, 4 };
        int S = 14;
        int arraySize = array.Length;
        long subsets = (long)Math.Pow(2, arraySize) - 1;

        long neededSubset = 0;
        int tempSum = 0;

        for (long i = 1; i < subsets; i++)
        {
            for (int y = 0; y < arraySize; y++)
            {
                if ((i >> y & 1) == 1)
                {
                    tempSum = tempSum + array[y];

                    if (tempSum == S)
                    {
                        neededSubset = i;
                        break;
                    }
                }
                if ((1 << y) > i)
                {
                    break;
                }
            }

            if (neededSubset != 0)
            {
                break;
            }
            tempSum = 0;
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
