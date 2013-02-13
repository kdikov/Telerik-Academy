/*
 * 5. Write a method that checks if the element at
 * given position in given array of integers is
 * bigger than its two neighbors (when such exist).
 */

using System;

class SubsetSum
{
    static void Main()
    {
        int[] array = { 1, 1, 5, 1, 3, 2, 5 };

        for (int i = -1; i < array.Length + 1; i++)
        {
            Console.WriteLine("Element with index [{0}] is bigger than its neighbors : {1}", i, BiggerThanNeighbors(array, i));
        }
    }

    private static bool BiggerThanNeighbors(int[] array, int index)
    {
        if (index >= 1 && index < array.Length - 1)
        {
            if (array[index] > array[index - 1] && array[index] > array[index + 1])
            {
                return true;
            }
        }

        return false;
    }
}
