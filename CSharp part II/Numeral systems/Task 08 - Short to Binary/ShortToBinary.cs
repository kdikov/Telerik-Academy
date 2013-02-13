using System;

public static class ShortExtension
{
    public static string ToBinary(this short number)
    {
        //short bitsNeeded = (short)Math.Log(number, 2) + 1;

        char[] result = new char[16];

        for (short i = 0; i < 16; i++)
        {
            if (((number >> i) & 1) == 0)
            {
                result[16 - 1 - i] = '0';
            }
            else
            {
                result[16 - 1 - i] = '1';
            }
        }

        return string.Join("", result);
    }
}

class ShortToBinary
{
    static void Main()
    {
        short number = -20300;

        string result = number.ToBinary();

        for (int i = 0; i < 16; i++)
        {
            Console.Write(result[i]);
            if ((i+1) % 4 == 0)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}