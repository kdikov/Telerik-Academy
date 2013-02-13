using System;

class Length20
{
    static void Main()
    {
        Console.Write("Enter string less than 20 characters: ");
        string input = Console.ReadLine();

        if (input.Length < 20)
        {
            input = input.PadRight(20, '*');
        }
        else if (input.Length > 20)
        {
            input = input.Substring(0, 20);
        }

        Console.WriteLine(input);
    }
}
