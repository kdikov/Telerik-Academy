/*
 * 4. Write a method that counts how many times given number
 * appears in given array. Write a test program to check
 * if the method is working correctly.
 */

using System;

class Appearances
{
    static void Main()
    {
        int[] array = { 1, 1, 5, 1, 3, 2, 5, 2, 0, 9, 8, 2, 7, 1 };

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("\"{0}\" appears {1} time(s) in the array", i, AppearsCount(array, i));
        }
    }

    private static int AppearsCount(int[] array, int searchedNumber)
    {
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == searchedNumber)
            {
                count++;
            }
        }

        return count;
    }
}
