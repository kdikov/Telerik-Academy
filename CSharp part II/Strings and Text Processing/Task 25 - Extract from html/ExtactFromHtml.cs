using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtactFromHtml
{
    static void Main()
    {
        string input =
@"
    <html>
      <head><title>News</title></head>
      <body><p><a href=""http://academy.telerik.com"">TelerikAcademy</a>
        aims to provide free real-world practical
        training for young people who want to turn into
        skillful .NET software engineers.</p></body>
    </html>
";

        Match titleMatch = Regex.Match(input, "<title>(.*?)</title>");
        string title = Regex.Replace(titleMatch.ToString(), "<title>(.*?)</title>", "$1");
        Console.WriteLine("Title: {0}",title);

        Console.Write("\nContent: ");
        Match bodyMatch = Regex.Match(input, @"<body>((.|[\n\r])*)</body>");
        string output = Regex.Replace(bodyMatch.ToString(), @"<.*?>", "");
        output = Regex.Replace(output, @"\n|\r|\t", " ");
        output = Regex.Replace(output, @"\s+", " ");

        Console.WriteLine(output);
        Console.WriteLine();
    }
}