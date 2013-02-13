using System;

class ReverseAverageLinear
{
    static void Main()
    {
        DrawMenu();
        while (GetChoice()) 
        { 
            DrawMenu(); 
        }

    }

    private static bool GetChoice()
    {
        Console.Write("Your choice: ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            return false;
        }

        switch (choice)
        {
            case 1:
                ReverseDigitsData();
                break;
            case 2:
                FindAverageData();
                break;
            case 3:
                LinearEquationData();
                break;
            default:
                Console.WriteLine("...");
                return false;
                break;
        }
        return true;
    }

    private static void LinearEquationData()
    {
        decimal a;
        decimal b;
        while (true)
        {
            DrawLine();
            Console.WriteLine("Linear equation");
            Console.Write("Enter a = ");

            if (!decimal.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                Console.Write("Enter b = ");
                if (!decimal.TryParse(Console.ReadLine(), out b))
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    if (a == 0 && b != 0)
                    {
                        Console.WriteLine("\"a\" can`t be 0!");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        if (a == 0 && b == 0)
        {
            Console.WriteLine("True for every \"x\"");
        }
        else
        {
            Console.WriteLine("x = {0}", LinearEquation(a, b));
        }
    }

    private static void FindAverageData()
    {
        decimal[] sequence;
        string input;
        while (true)
	    {
	        DrawLine();
            Console.WriteLine("Enter non empty sequence of numbers");
            Console.WriteLine("Separate them with \",\". Example: 3, 5, 6");
            Console.Write("Your sequence: ");
            input = Console.ReadLine();
            if (!ValidateSequence(input, out sequence))
            {
                Console.WriteLine("Invalid input or empty sequence");
            }
            else
            {
                break;
            }
	    }

        decimal result = FindAverage(sequence);
        Console.WriteLine("Average = {0}", result);
    }

    private static bool ValidateSequence(string input, out decimal[] sequenceOutput)
    {
        string[] numbers = input.Split(',');
        sequenceOutput = new decimal[numbers.Length];
        if (numbers.Length == 0)
        {
            return false;
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            if (!decimal.TryParse(numbers[i], out sequenceOutput[i]))
            {
                return false;
            }
        }

        return true;
    }

    private static void ReverseDigitsData()
    {
        DrawLine();
        string input = "";
        decimal number = 0;

        while (true)
        {
            Console.Write("Enter non-negative number: ");
            input = Console.ReadLine();

            if (decimal.TryParse(input, out number))
            {
                if (number < 0)
                {
                    Console.WriteLine("Number must be positive!");
                }
                else
                {
                    break;
                }
            }  
        }

        Console.WriteLine("Reversed number is: {0}", ReverseDigits(number));
        DrawLine();
    }

    private static void DrawMenu()
    {
        DrawLine();
        Console.WriteLine("Tasks:");
        Console.WriteLine("1. Reverses the digits of a number");
        Console.WriteLine("2. Calculates the average of a sequence of integers");
        Console.WriteLine("3. Solves a linear equation a*x + b = 0");
        Console.WriteLine("*  Any other input to quit");
        DrawLine();
    }

    private static void DrawLine()
    {
        Console.WriteLine("===================================================");
    }

    private static decimal LinearEquation(decimal a, decimal b)
    {
        return -b / a;
    }

    private static decimal FindAverage(decimal[] sequence)
    {
        decimal sum = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            sum = sum + sequence[i];
        }

        return sum / sequence.Length;
    }

    private static decimal ReverseDigits(decimal number)
    {
        char[] digits = number.ToString().ToCharArray();
        string newNumber = "";

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            newNumber = newNumber + digits[i];
        }

        return decimal.Parse(newNumber);
    }
}