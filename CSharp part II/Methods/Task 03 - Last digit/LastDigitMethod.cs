using System;

class LastDigitMethod
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(LastDigit(number));
    }

    private static string LastDigit(int number)
    {
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return digits[number % 10];
    }
}