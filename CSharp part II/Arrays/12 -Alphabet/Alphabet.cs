/*
 * 12. Write a program that creates an array containing all letters from the alphabet (A-Z). 
 * Read a word from the console and print the index of each of its letters in the array.
 */

using System;

class Alphabet
{
    static void Main()
    {
        char[] Alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
        'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
        'W', 'X', 'Y', 'Z'};

        Console.Write("Your word: ");
        string word = Console.ReadLine();

        int index = 0;
        foreach (char letter in word)
        {
            if (ArrayBinarySearch(Alphabet, char.ToUpper(letter), out index))
            {
                Console.WriteLine("Letter {0} is with index [{1}]", letter, index);
            }
            else
            {
                Console.WriteLine("{0} is not a letter");
            }
        }
    }

    public static bool ArrayBinarySearch(char[] array, char searchedElement, out int foundIndex)
    {
        int lowEnd = 0;
        int highEnd = array.Length;
        int middle = 1;

        while (highEnd - lowEnd != 0)
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