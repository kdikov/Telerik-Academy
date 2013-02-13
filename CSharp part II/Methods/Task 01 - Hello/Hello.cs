using System;

class Hello
{
    static void Main()
    {
        HelloName();
    }

    private static void HelloName()
    {
        Console.Write("Enter your name: ");
        Console.WriteLine("Hello, {0}!", Console.ReadLine());
    }
}