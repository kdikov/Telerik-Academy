//You are given a text. Write a program that changes the text in all regions 
//surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 
//Example:
//We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//The expected result:
//We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Text.RegularExpressions;
using System.Text;

class UpCase
{
    static void Main()
    {
        string input = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string[] patterns = { "<upcase>", "</upcase>" };
        int startIndex = 0;
        int openTagIndex = 0;
        int closeTagIndex = 0;

        StringBuilder newString = new StringBuilder();
        while (true)
        {
            openTagIndex = input.IndexOf(patterns[0], startIndex);

            if (openTagIndex < 0)
            {
                newString.Append(input.Substring(startIndex, input.Length - startIndex));
                break;
            }
            else
            {
                newString.Append(input.Substring(startIndex, openTagIndex - startIndex));
                closeTagIndex = input.IndexOf(patterns[1], startIndex);

                for (int i = openTagIndex + patterns[0].Length; i < closeTagIndex; i++)
                {
                    newString.Append(input[i].ToString().ToUpper());
                }

                startIndex = closeTagIndex + patterns[1].Length;
            }
        }

        Console.WriteLine(newString);
    }
}
