/*
 * 15.Write a program that finds all prime numbers
 * in the range [1...10 000 000]. Use the sieve of
 * Eratosthenes algorithm (find it in Wikipedia).
 */
using System;

class ClassName
{
    static void Main()
    {
        bool[] numbers = new bool[10000000];

        for (int i = 0; i < 10000000; i = i + 2)
        {
            numbers[i] = false;
            numbers[i + 1] = true;
        }

        int limit = (int)Math.Sqrt(1000000);

        for (int i = 3; i < limit; i++)
        {
            if (i % 2 != 0 && numbers[i] == true)
            {
                for (int y = i*i; y < 10000000; y = y + i)
                {
                    numbers[y] = false;
                }
            }
        }
        numbers[2] = true;
        for (int i = 2; i < 10000; i++) //change to 10000000 if you want to wait an hour to print them all ;)
        {
            if (numbers[i]==true)
            {
                Console.WriteLine(i);
            }
        }
    }
}