using System;

class TriangleArea
{
    static void Main()
    {
        DrawMenu();
        GetChoice();
    }

    private static void DrawMenu()
    {
        Console.WriteLine("Available methods for calculating area of triangle");
        DrawLine();
        Console.WriteLine("1) By given side and an altitude to it");
        Console.WriteLine("2) Three sides");
        Console.WriteLine("3) Two sides and angle between them");
        DrawLine();
        Console.Write("Your choice (1,2,3 or any other to quit): ");
    }

    private static void GetChoice()
    {
        string input = Console.ReadLine();
        DrawLine();
        int choice = 0;
        double[] output;
        double result = 0;

        if (int.TryParse(input, out choice))
        {
            switch (choice)
            { 
                case 1:
                    output = GetData("Side a", "Altitude h");
                    result = Area(output);
                    break;
                case 2:
                    output = GetData("Side a", "Side b", "Side c");
                    result = Area(output);
                    break;
                case 3:
                    output = GetData("Side a", "Side b", "Angle (degrees)");
                    result = Area(output, angle: true);
                    break;
                default:
                    break;
            }
        }

        DrawLine();
        if (result != 0)
        {
            if (result > 0)
            {
                Console.WriteLine("Area = {0}", result);
            }
            else if (double.IsNaN(result) || result < 0)
            {
                Console.WriteLine("No such triangle!");
            }
        }
        else
        {
            Console.WriteLine("Have a nice day!");
        }
        DrawLine();

    }

    private static double Area(double[] inputData, bool angle = false)
    {
        if (!angle)
        {
            if (inputData.Length == 2)
            {
                return inputData[0] * inputData[1] / 2;
            }
            else
            {
                double p = (inputData[0] + inputData[1] + inputData[2]) / 2;
                return Math.Sqrt(p * (p - inputData[0]) * (p - inputData[1]) * (p - inputData[2]));
            }
        }
        else
        {
            return (inputData[0] * inputData[1] * Math.Sin(Math.PI * inputData[2] / 180)) / 2;
        }
    }

    private static double[] GetData(params string[] variables)
    {
        double[] output = new double[variables.Length];

        for (int i = 0; i < variables.Length; i++)
        {
            Console.Write(variables[i] + " = ");
            output[i] = double.Parse(Console.ReadLine());
        }

        return output;
    }

    private static void DrawLine()
    {
        Console.WriteLine("==================================================");
    }
}