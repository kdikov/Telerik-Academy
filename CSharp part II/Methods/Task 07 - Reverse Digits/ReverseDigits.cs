/*
 * 7. Write a method that reverses the digits of
 * given decimal number. Example: 256 -> 652.
 */

using System;
using System.Text;

class SubsetSum
{
    static void Main()
    {
        decimal number = -987.6543210M;

        Console.WriteLine(ReverseDigits(number));
    }

    private static string ReverseDigits(decimal number)
    {
        char[] newNumber = number.ToString().ToCharArray();
        Array.Reverse(newNumber);

        int elementsToPrint = newNumber.Length;

        if (newNumber[newNumber.Length - 1] == '-') 
        {
            elementsToPrint--;
        }

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < elementsToPrint; i++)
        {
            result.Append(newNumber[i]);
        }
        return result.ToString();
    }
}
