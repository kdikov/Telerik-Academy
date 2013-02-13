using System;
using System.Text.RegularExpressions;
class SubstringCount
{
    static void Main()
    {
        string input = "This is another test.tHE end";
        string pattern = "th";
        int count = Regex.Matches(input, pattern, RegexOptions.IgnoreCase).Count;
        Console.WriteLine("Number of appearance: {0}", count);
    }
}