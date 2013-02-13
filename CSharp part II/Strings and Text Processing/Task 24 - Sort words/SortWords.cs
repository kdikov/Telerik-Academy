using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SortWords
{
    static void Main()
    {
        string input = "Test for sorting words in alphabetical order. Aa ab aab aba";

        MatchCollection wordsMatchCollection = Regex.Matches(input, @"\b\w+\b");
        string[] words = new string[wordsMatchCollection.Count];

        for (int i = 0; i < wordsMatchCollection.Count; i++)
        {
            words[i] = wordsMatchCollection[i].ToString();
        }

        Array.Sort(words);

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}