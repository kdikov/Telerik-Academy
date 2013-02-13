using System;
using System.Text;
using System.Text.RegularExpressions;

class Palindromes
{
    static void Main()
    {
        string input = "Test for palindromes like exe, ABBA and lamal.";
        MatchCollection words = Regex.Matches(input, @"\b\w+\b");
        bool symmetry = true;
        string word = "";
        foreach (var wordT in words)
        {
            word = wordT.ToString();
            for (int i = 0; i < word.Length/2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    symmetry = false;
                }
            }

            if (symmetry)
            {
                Console.WriteLine(word);
            }
            else
            {
                symmetry = true;
            }
        }
    }
}