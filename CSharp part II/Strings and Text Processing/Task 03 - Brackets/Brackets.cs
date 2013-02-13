using System;

class Brackets
{
    static void Main()
    {
        string expression = "(2+3(";

        int brackets = 0;
        bool result = true;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                brackets++;
            }
            else if (expression[i] == ')')
            {
                brackets--;
            }

            if (brackets < 0)
            {
                result = false;
                break;
            }
        }

        if (brackets > 0)
        {
            result = false;
        }

        Console.WriteLine("Expression is valid: {0}", result);
    }
}