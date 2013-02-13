 //2.Write a method ReadNumber(int start, int end) that enters
 //an integer number in given range [start…end]. 
 //If an invalid number or non-number text is entered,
 //the method should throw an exception. Using this method 
 //write a program that enters 10 numbers:

 // a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class NumberInRange
{
    static void Main()
    {
        int[] numbers = new int[10];

        int downRange = 1;
        for (int i = 0; i < 10; i++)
        {
            do
            {
                Console.Write("N{2}) Enter integer number in range ({0}-{1}): ", downRange, 100, i+1);
            } while (!ReadNumber(downRange, 100, out numbers[i]));

            downRange = numbers[i];
        }
    }

    private static bool ReadNumber(int p1, int p2, out int number)
    {
        number = -1;
        try
        {
            number = int.Parse(Console.ReadLine());
            if (number <= p1 || number >= p2)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return true;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input - Not a number!");
            return false;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Number should be in range ({0}-{1})",p1, p2);
            return false;
        }
    }
}