using System;
using System.Text.RegularExpressions;

class ForbiddenWords
{
    static void Main()
    {
        string input = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] patterns = {"PHP", "CLR", "Microsoft"};

        for (int i = 0; i < patterns.Length; i++)
        {
            input = Regex.Replace(input, @"\b" + patterns[i] + @"\b", "".PadLeft(patterns[i].Length,'*'));
        }
        Console.WriteLine(input);
    }
}