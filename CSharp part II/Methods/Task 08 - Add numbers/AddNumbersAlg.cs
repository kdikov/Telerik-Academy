using System;
using System.Text;

class AddNumbersAlg
{
    static void Main()
    {
        byte[] firstNumber = new byte[] { 1, 2, 1 };
        byte[] secondNumber = new byte[] { 9, 1 };

        byte[] result = AddNumbers(firstNumber, secondNumber);

        Console.WriteLine(WriteNumber(firstNumber) + " + " + WriteNumber(secondNumber) + " = " + WriteNumber(result));
    }

    private static string WriteNumber(byte[] arr)
    {
        StringBuilder result = new StringBuilder();

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            result.Append(arr[i]);
        }

        return result.ToString();
    }

    private static byte[] AddNumbers( byte[] arr1, byte[] arr2)
    {
        byte[] firstArray;
        byte[] secondArray;

        if (arr1.Length > arr2.Length)
        {
            firstArray = arr1;
            secondArray = arr2;
        }
        else
        {
            firstArray = arr2;
            secondArray = arr1;
        }

        int max = firstArray.Length;
        int min = secondArray.Length;

        byte[] newNumber = new byte[max + 1];
        byte[] newNumber2 = new byte[max];

        byte carry = 0;
        byte lastDigit = 0;

        for (int i = 0; i < min; i++)
        {
            carry = AddNumbersCarry(ref lastDigit,(byte)(firstArray[i] + carry), secondArray[i]);
            newNumber2[i] = lastDigit;
        }

        while (min < max)
        {
            carry = AddNumbersCarry(ref lastDigit,firstArray[min], carry);
            newNumber2[min++] = lastDigit;  
        }

        if (carry == 1)
        {
            for (int i = 0; i < max; i++)
            {
                newNumber[i] = newNumber2[i];
            }
            newNumber[min] = 1;
        }

        return min > max ? newNumber : newNumber2;
    }

    private static byte AddNumbersCarry(ref byte lastDigit, byte p1, byte p2)
    {
        byte carry = 0;
        if (p1 + p2 > 9)
        {
            carry = 1;
        }

        lastDigit = (byte)(p1 + p2 - carry*10);
        return carry;
    }
}