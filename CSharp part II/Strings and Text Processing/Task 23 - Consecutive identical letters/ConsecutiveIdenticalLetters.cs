using System;
using System.Text.RegularExpressions;
using System.Text;
class ConsecutiveIdenticalLetters
{
    static void Main()
    {
        string input = "aaaaaaaabbbbssssssddaa";

        StringBuilder output = new StringBuilder();

        output.Append(input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i]!= input[i-1])
            {
                output.Append(input[i]);
            }
        }

        Console.WriteLine(input);
        Console.WriteLine(output);
    }
}