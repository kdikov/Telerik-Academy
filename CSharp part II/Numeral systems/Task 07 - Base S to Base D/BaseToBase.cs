using System;

public static class StringExtension
{
    public static string ConvertToBase(this string number, int base1, int base2)
    {
        string newNumber = "";

        int decimalNum = 0;
        char current = new char();
        int currentNum = new int();
        for (int i = 0; i < number.Length; i++)
        {
            current = number[number.Length - i - 1];
       
            if (current >= 'A')
            {
                currentNum = current - 'A' + 10;
            }
            else
            {
                currentNum = current - '0';
            }
            decimalNum = decimalNum + currentNum * (int)Math.Pow(base1, i);
        }
       
        string hex = "";
        char currentSymbol = new char();
        for (int i = decimalNum; i > 0; i = i / base2)
        {
            if (i % base2 >= 10)
            {
                currentSymbol = (char)('A' + i % base2 - 10);
            }
            else
            {
                currentSymbol = (char)('0' + i % base2);
            }
            hex = currentSymbol + hex;
        }
        return hex;
    }
}

class BaseToBase
{
    static void Main()
    {
        string number = "5";

        string newNumber = number.ConvertToBase(4, 10);
        Console.WriteLine(newNumber);
    }
}