/* Write a program that reads
 * two arrays from the console
 * and compares them element by element.
 */

using System;

class CompareArrays
{
    static void Main()
    {
        Console.Write("Enter arrays size: ");
        int size = int.Parse(Console.ReadLine());
        int[] firstArray = new int[size];
        int[] secondArray = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("firstArray[{0}] = ", i);
            firstArray[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < size; i++)
        {
            Console.Write("secondArray[{0}] = ", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();

        for (int i = 0; i < size; i++) // Output element by element comparison result
        {
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("firstArray[{0}] = secondArray[{0}]",i);
            }
            else if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("firstArray[{0}] > secondArray[{0}]",i);
            }
            else 
            {
                Console.WriteLine("firstArray[{0}] < secondArray[{0}]",i);
            }
        }

        Console.WriteLine();

        bool identicalArrays = true;
        for (int i = 0; i < size; i++) // Check if arrays are identical 
        {
            if (firstArray[i]!=secondArray[i])
            {
                identicalArrays = false;
                break;
            }
        }

        Console.WriteLine(identicalArrays ? "Arrays are identical" : "Arrays are not identical");
        Console.WriteLine();
    }
}