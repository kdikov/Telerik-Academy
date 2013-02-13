/*
 * 10.Write a program to calculate n! for each n in the range [1..100]. 
 * Hint: Implement first a method that multiplies a number represented
 * as array of digits by given integer number. 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class MultiplyingNumbers // represented as array of digits // Factorial 100+
{
    static void Main()
    {
        int[] fact5 = FindFactorial(20); //
    }

    private static int[] FindFactorial(int p)
    {
        List<int> lastNumber = new List<int>();
        lastNumber.Add(1);

        for (int i = 1; i <= p; i++)
        {
            int[] currentNumber = MultiplyNumbers(lastNumber.ToArray(), i);
            Console.WriteLine("{0}! = {1}", i, WriteNumber(currentNumber));
            lastNumber = currentNumber.ToList();
        }

        return lastNumber.ToArray();
    }


    private static int[] MultiplyNumbers(int[] firstNumber, int number)
    {
        int[] multiplyResult = new int[number.ToString().Length + firstNumber.Length];
        int[] secondNumber = IntDigitsToArray(number); 
        
        int digitsMultiplyResult;

        for (int i = 0; i < secondNumber.Length; i++)
        {
            if (secondNumber[i] == 0)
            {
                continue;
            }

            for (int y = 0; y < firstNumber.Length; y++)
            {
                digitsMultiplyResult = secondNumber[i] * firstNumber[y];

                multiplyResult[y + i] = multiplyResult[y + i] + digitsMultiplyResult % 10;
                if (multiplyResult[y + i] > 9)
                {
                    multiplyResult[y + i + 1] = multiplyResult[y + i + 1] + multiplyResult[y + i] / 10;
                    multiplyResult[y + i] = multiplyResult[y + i] % 10;
                }
                multiplyResult[y + i + 1] = multiplyResult[y + i + 1] + digitsMultiplyResult / 10;
            }
        }

        return RemoveZeroes(multiplyResult);
    }

    //Remove zeroes from the end of the array
    private static int[] RemoveZeroes(int[] multiplyResult)
    {
        List<int> digitsArray = multiplyResult.ToList();

        for (int i = multiplyResult.Length - 1; i >= 0; i--)
        {
            if (multiplyResult[i] != 0)
            {
                break;
            }

            else
            {
                digitsArray.RemoveAt(i);
            }
        }
        return digitsArray.ToArray();
    }

    //Convert integer number digits to array
    private static int[] IntDigitsToArray(int number)
    {
        int[] array = new int[number.ToString().Length];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = number % 10;
            number = number / 10;
        }
        return array;
    }

    //Convert array with digits to number as string
    private static string WriteNumber(int[] arr)
    {
        StringBuilder result = new StringBuilder();

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            result.Append(arr[i]);
        }
        return result.ToString();
    }
}