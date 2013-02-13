using System;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class EmailAddresses
{
    static void Main()
    {
        string input = "This is a test for extraxting em@il.s from a string. Test@email.com.";
        MatchCollection emails = Regex.Matches(input, @"\S+@\S+\.\S+\b");

        foreach (var email in emails)
        {
            Console.WriteLine(email);   
        }
    }
}