using System;

class DayOfTheWeek
{
    static void Main()
    {
        DateTime date = new DateTime();
        date = DateTime.Now;
        Console.WriteLine("Today is {0}", date.DayOfWeek); 
    }
}