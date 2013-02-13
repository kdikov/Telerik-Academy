using System;

class Dates
{
    static void Main()
    {
        string firstDate = "02.01.2013";
        string secondDate = "2.02.2013";

        DateTime startDate = DateTime.Parse(firstDate);
        DateTime endDate = DateTime.Parse(secondDate);
        TimeSpan diff = endDate - startDate;

        int daysDiff = diff.Days;
        Console.WriteLine(daysDiff);
    }
}