using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class WordsCount
{
    static void Main()
    {
        string input = "Test for counting repeating words in string. Testing for repeating.";

        MatchCollection words = Regex.Matches(input, @"\b\w+\b");

        List<string> wordsList = new List<string>();

        foreach (var word in words)
        {
            wordsList.Add(word.ToString());
        }

        var groupedList = wordsList.GroupBy(x=>x);

        foreach (var word in groupedList)
        {
            Console.WriteLine("Word {0} is found {1} times", word.Key, word.Count());
        }
    }
}