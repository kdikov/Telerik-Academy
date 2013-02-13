using System;

public static class IntExtension
{
    public static string ToHexadecimal(this int number)
    {
        string hexa = "";
        char currentSymbol = new char();
        for (int i = number; i > 0; i = i/16)
        {
            if (i % 16 >= 10)
            {
                currentSymbol = (char)('A' + i % 16 - 10);
            }
            else
            {
                currentSymbol = (char)('0' + i % 16);
            }
            hexa = currentSymbol + hexa;
        }
        return hexa;
    }
}

class DecimalToHexadecimal
{
    static void Main()
    {
        int number = 29;

        string hexadecimal = number.ToHexadecimal();
        Console.WriteLine(hexadecimal);
    }
}