using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class ReverseWords
{
    static void Main()
    {
        string input = "C# is not C++, not PHP and not Delphi!";
        char[] separatorsPattern = new char[] { ',', ' ', '!', '?', '.' };

        string[] words = input.Split(separatorsPattern, StringSplitOptions.RemoveEmptyEntries);
        string[] sepapators = Regex.Split(input, "[A-Za-z0-9#+]+[A-Za-z0-9#+]");

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            output.Append(sepapators[i]);    
            output.Append(words[words.Length - 1 - i]);
        }

        for (int i = words.Length; i < sepapators.Length; i++)
        {
            output.Append(sepapators[i]);
        }

        Console.WriteLine(output);
    }
}