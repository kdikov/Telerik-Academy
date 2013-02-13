using System;

class GetMaxMethod
{
    static void Main()
    {
        int[] numbers = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Number {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(GetMax(numbers[0], GetMax(numbers[1],numbers[2])));
    }

    private static int GetMax(int number1, int number2)
    {
        if (number1 >= number2)
        {
            return number1;
        }
        else
        {
            return number2;
        }
    }
}