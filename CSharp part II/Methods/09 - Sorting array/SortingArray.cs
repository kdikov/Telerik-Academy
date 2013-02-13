/*
 * Write a method that returns the maximal element
 * in a portion of array of integers starting at
 * given index. Using it write another method that
 * sorts an array in ascending / descending order.
 */

using System;
using System.Collections.Generic;

namespace SortingAlg
{
    class MaximalElement
    {
        static void Main()
        {
            int[] elements = { 3, 2, 9, 1, 11, 2, 4, 91, 12, 7, 6 };

            elements.Asc();
            //or Sorting.Asc(elements);
            Console.WriteLine(string.Join(", ", elements));

            elements.Desc();
            //or Sorting.Desc(elements);
            Console.WriteLine(string.Join(", ", elements));
        }
    }

    public static class Sorting
    {
        public static void Asc(this int[] arr) // Ascending
        {
            Sorting.Desc(arr);

            for (int i = 0; i < arr.Length / 2; i++)
            {
                //Reversing from Descending to Ascending
                ChangeElements(arr, i, arr.Length - 1 - i);
            }
        }

        public static void Desc(this int[] arr) // Descending
        {
            for (int i = 0; i < arr.Length; i++)
            {
                //Max from [0...last] goes at index [0], the next [1...last] goest at index [1] and so on... 
                ChangeElements(arr, GetMax(arr, i), i); 
            }
        }

        //Exchanging values between two elements
        public static void ChangeElements(int[] arr, int firstIndex, int secondIndex)
        {
            int tempHolder = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = tempHolder;
        }

        //Get maximal element in range from array
        private static int GetMax(int[] arr, int index)
        {
            int max = arr[index];
            int maxIndex = index;
            for (int i = index; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }
}
