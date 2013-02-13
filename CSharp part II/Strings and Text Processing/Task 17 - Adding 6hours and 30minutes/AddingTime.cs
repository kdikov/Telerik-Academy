using System;

class AddingTime
{
    static void Main()
    {
        string input = "02.02.2013 23:12:55";

        DateTime inputDate = DateTime.Parse(input);
        DateTime newDate = inputDate.AddHours(6).AddMinutes(30);
        Console.WriteLine("{0:dd.MM.yyyy hh:mm:ss}", inputDate);
        Console.WriteLine("{0:dd.MM.yyyy hh:mm:ss}", newDate);
    }
}