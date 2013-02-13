using System;

public static class StringExtension
{
    public static string Reverse(this string stringInput)
    {
        char[] chars = stringInput.ToCharArray();
        Array.Reverse(chars);
        return string.Join("", chars);
    }
}

class ReverseString
{
    static void Main()
    {
        string test = "this is a test";
        Console.WriteLine(test.Reverse());
    }
}