using System;

public static class IntExtension
{
    public static string ToBinary(this int number)
    {
        int bitsNeeded = (int)Math.Log(number, 2) + 1;

        char[] result = new char[bitsNeeded];

        for (int i = 0; i < bitsNeeded; i++)
        {
            if (((number >> i) & 1) == 0)
            {
                result[bitsNeeded - 1 - i] = '0';
            }
            else
            {
                result[bitsNeeded - 1 - i] = '1';
            }
        }

        return string.Join("",result);
    }
}

class DecimalToBinary
{
    static void Main()
    {
        int number = 100;

        string result = number.ToBinary();
        Console.WriteLine(result);
    }
}