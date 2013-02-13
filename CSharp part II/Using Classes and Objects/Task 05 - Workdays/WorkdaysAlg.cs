using System;

class WorkdaysAlg
{
    static DateTime[] Holidays = 
    { 
        new DateTime(2013, 02, 01),
        new DateTime(2013, 02, 03),
        new DateTime(2013, 02, 05),
        new DateTime(2013, 12, 24),
        new DateTime(2013, 12, 25),
        new DateTime(2013, 12, 30),
        new DateTime(2013, 12, 31)
    };

    static void Main()
    {
        DateTime endDate = new DateTime(2013, 2, 2);

        int workdays = Workdays(endDate);

        Console.WriteLine(workdays);
    }

    private static int Workdays(DateTime endDate)
    {
        int workdays = 0;
        DateTime tempDate = new DateTime();
        tempDate = DateTime.Today;

        while (tempDate < endDate)
        {
            if (tempDate.DayOfWeek != DayOfWeek.Saturday && tempDate.DayOfWeek != DayOfWeek.Sunday)
            {
                workdays++;
            }
            tempDate = tempDate.AddDays(1);
        }

        workdays = RemoveHolidays(workdays, endDate);

        return workdays;
    }

    private static int RemoveHolidays(int workdays, DateTime endDate)
    {
        foreach (var holiday in Holidays)
        {
            if (holiday < endDate)
            {
                if (holiday.DayOfWeek != DayOfWeek.Saturday && holiday.DayOfWeek != DayOfWeek.Sunday)
                {
                    workdays--;
                }
            }
        }
        return workdays;
    }

}