using System;

public static class StringExtension
{
    public static int ToDecimal(this string binary)
    {
        int number = 0;
        for (int i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                number = number | (1 << (binary.Length - i - 1));
            }   
        }
        return number;
    }
}

class BinaryToDecimal
{
    static void Main()
    {
        string binary = "110110";

        int result = binary.ToDecimal();
        Console.WriteLine(result);
    }
}