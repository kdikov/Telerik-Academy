using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("Enter year to be checked: ");
        int year = int.Parse(Console.ReadLine());

        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("Year {0} is leap!", year);    
        }
        else
        {
            Console.WriteLine("Year {0} is not leap!", year);    
        }
    }
}