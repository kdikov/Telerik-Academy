/*
 * 11.Write a program that finds the index of given element in a sorted array 
 * of integers by using the binary search algorithm (find it in Wikipedia).
 */

using System;

class BinarySearch
{
    static void Main()
    {
        int[] numbers = {0, 1, 2, 5, 6, 7, 9, 13, 15, 18, 22};

        Console.Write("Element to search for: ");
        int element = int.Parse(Console.ReadLine());
        int index;
        if (ArrayBinarySearch(numbers, element, out index))
        {
            Console.WriteLine("Searched element exist and is with index [{0}]", index);
        }
        else
        {
            Console.WriteLine("Searched element does not exist");
        }
    }

    public static bool ArrayBinarySearch(int[] array, int searchedElement, out int foundIndex)
    {
        int lowEnd = 0;
        int highEnd = array.Length;
        int middle = 1;
        
        while (highEnd - lowEnd !=0)
        {
            middle = (highEnd + lowEnd) / 2;
            if (array[middle] < searchedElement)
            {
                lowEnd = middle;
            }
            else if (array[middle] > searchedElement)
            {
                highEnd = middle;
            }
            else
            {
                foundIndex = middle;
                return true;
            }
        }
        foundIndex = -1;
        return false;
    }
}