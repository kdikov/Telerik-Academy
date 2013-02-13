//Write a program that extracts from a given text all sentences containing given word.

//Example: The word is "in". The text is:
//We are living in a yellow submarine. We don't have anything else. 
//Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//The expected result is:
//We are living in a yellow submarine.
//We will move out of it in 5 days.

//Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;
using System.Text;
using System.Text.RegularExpressions;

class WordInSentences
{
    static void Main()
    {
        string input =
@"We are living in a yellow submarine. We don't have anything else. 
Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        string pattern = "in";
        int startIndex = 0;
        int endIndex = 0;
        string currentSent = "";

        input = input.Replace(". ",".");
        string[] sentences = input.Split('.');

        StringBuilder output = new StringBuilder();
        for (int i = 0; i < sentences.Length; i++)
	    {
            if (Regex.Match(sentences[i], @"\b" + pattern + @"\b").Success)
            {
                output.Append(sentences[i]);
                output.Append(".\n");
            }
	    }

        Console.WriteLine(output);
    }
}
