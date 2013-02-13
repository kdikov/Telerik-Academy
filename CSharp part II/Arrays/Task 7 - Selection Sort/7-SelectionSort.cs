/*
Sorting an array means to arrange its elements in 
increasing order. Write a program to sort an array. Use the "selection sort" algorithm:
Find the smallest element, move it at the first position, 
find the smallest from the rest, move it at the second position, etc.
 */
 
using System;

class SelectionSortAlg
{
    public static int[] SelectionSort(int[] arrayToSort)
    {
        int smallest;
        int smallestIndex;
        int arraySize = arrayToSort.Length;

        for (int i = 0; i < arraySize; i++)
        {
            smallest = arrayToSort[i];
            smallestIndex = i;
            for (int y = i; y < arraySize; y++)
            {
                if (smallest > arrayToSort[y])
                {
                    smallest = arrayToSort[y];
                    smallestIndex = y;
                }
            }

            if (smallestIndex != i)
            {
                arrayToSort[i] = arrayToSort[i] + arrayToSort[smallestIndex];
                arrayToSort[smallestIndex] = arrayToSort[i] - arrayToSort[smallestIndex];
                arrayToSort[i] = arrayToSort[i] - arrayToSort[smallestIndex];
            }
        }

        return arrayToSort;
    }

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

        numbers = SelectionSort(numbers);

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}