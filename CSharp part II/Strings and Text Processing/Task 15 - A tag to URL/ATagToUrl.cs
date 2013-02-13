using System;
using System.Text.RegularExpressions;

class ATagToUrl
{
    static void Main()
    {
        string input = @"<p>Please visit <a href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

        string output = Regex.Replace(input, @"<a href=""(.*?)"">(.*?)</a>", "[URL=$1]$2[/URL]");
        Console.WriteLine(output);
    }
}