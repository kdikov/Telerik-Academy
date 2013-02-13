using System;

public static class StringExtension
{
    public static int ToDecimal(this string hex)
    {
        int decimalNum = 0;
        char current = new char();
        int currentNum = new int();
        for (int i = 0; i < hex.Length; i++)
        {
            current = hex[hex.Length - i - 1];

            if ( current >= 'A')
            {
                currentNum = current - 'A' + 10;
            }
            else
            {
                currentNum = current - '0';
            }
            decimalNum = decimalNum + currentNum*(int)Math.Pow(16, i);
        }

        return decimalNum;
    }
}

class HexadecimalToDecimal
{
    static void Main()
    {
        string hexadecimal = "3F1";
        int decimalNum = hexadecimal.ToDecimal();
        Console.WriteLine(decimalNum);
    }
}