using System;
using System.Text.RegularExpressions;
using System.Globalization;

class ExtractDates
{
    static void Main()
    {
        string input = "Test date 02.02.2013г. and 2.02.2013.";

        MatchCollection dates = Regex.Matches(input, @"\b[0-9]{1,2}.[0-9]{1,2}.[0-9]{2,4}");

        DateTime date = new DateTime();
        var cultureCanada = new CultureInfo("en-CA");

        foreach (var tDate in dates)
        {
            if (DateTime.TryParse(tDate.ToString(), out date))
            {
                Console.WriteLine(date.ToString(cultureCanada));
            }
        }
    }
}