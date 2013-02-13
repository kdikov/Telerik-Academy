//1.Write a program that reads an integer number and
//calculates and prints its square root. If the number
//is invalid or negative, print "Invalid number". 
//In all cases finally print "Good bye". Use try-catch-finally.

using System;

class SquareRoot
{
    static void Main()
    {
        Console.Write("Enter integer number: ");

        try
        {
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            { 
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Console.WriteLine("Square root of {0} is {1}", number, Math.Sqrt(number));
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number");
            //throw;
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}