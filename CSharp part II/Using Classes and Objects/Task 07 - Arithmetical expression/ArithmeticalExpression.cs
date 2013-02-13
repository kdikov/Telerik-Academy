using System;
using System.Collections;
using System.Collections.Generic;

class ArithmeticalExpression
{

    static void Main()
    {
        //last minute solution - Pow not working :}
        string expression;
        expression = "1 + 3*2 + 8";
        //expression = "(1 + 2)*3 - 4/2";
        //expression = "(2 + 1)*(2 + 1)";
        //expression = "(7-3)/2 - 2";
        //expression = "sqrt(2+2)*2 + 3";

        Console.WriteLine(expression);
        Console.WriteLine("Result: " + expression.CalculateExpression());

    }
}

public static class StringExtension
{
    public static Dictionary<string, int> operators = new Dictionary<string, int>() 
    {
        {"+", 0},
        {"-", 0},
        {"*", 1},
        {"/", 1},
        {"s", 7},
        {"p", 8},
        {"(", 5},
        {")", 6}
    };


    public static double CalculateExpression(this string expression)
    {
        expression = PrepareExpression(expression) + " ";
        Stack stack = new Stack();
        stack = StackExpression(expression);
        expression = null;
        string currentToken = "";
        while (stack.Count > 0)
        {
            currentToken = stack.Pop().ToString();
            if (currentToken != " ")
            {
                expression += currentToken + " ";
            }
        }
        expression = expression.TrimEnd(' ');
        string[] output = expression.Split(' ');

        int numberL = 0;
        int numberLInd = 0;
        int numberR = 0;
        int numberRInd = 0;
        int count = 0;
        for (int i = output.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(output[i].ToCharArray()[0]))
            {
                count = 0;
                while (true)
                {
                    count++;
                    if (int.TryParse(output[i + count], out numberL))
                    {
                        numberLInd = i + count;
                        break;
                    }
                }
                while (true)
                {
                    count++;
                    if (int.TryParse(output[i + count], out numberR))
                    {
                        numberRInd = i + count;
                        break;
                    }
                }

                if (output[i] == "+")
                {
                    output[i] = "x";
                    output[numberLInd] = (int.Parse(output[numberLInd]) + int.Parse(output[numberRInd])).ToString();
                    output[numberRInd] = "x";
                }
                if (output[i] == "*")
                {
                    output[i] = "x";
                    output[numberLInd] = (int.Parse(output[numberLInd]) * int.Parse(output[numberRInd])).ToString();
                    output[numberRInd] = "x";
                }
                if (output[i] == "-")
                {
                    output[i] = "x";
                    output[numberLInd] = (int.Parse(output[numberRInd]) - int.Parse(output[numberLInd])).ToString();
                    output[numberRInd] = "x";
                }
                if (output[i] == "/")
                {
                    output[i] = "x";
                    output[numberLInd] = (int.Parse(output[numberRInd]) / double.Parse(output[numberLInd])).ToString();
                    output[numberRInd] = "x";
                }
            }
        }

        string resultString = string.Join("", output);
        resultString = resultString.Replace("x", "");
        return double.Parse(resultString);
    }

    private static Stack StackExpression(string expression)
    {
        Stack outputStack = new Stack();
        Stack operatorStack = new Stack();
        char tokenPart = new char();
        char lastOperator = new char();
        int currentIndex;
        int lastIndex;
        string powSqrtString = "";
        int braketCount = 0;
        int powValue = 0;
        for (int i = 0; i < expression.Length; i++)
        {

            string currentToken = "";
            tokenPart = expression[i];

            if (tokenPart == 's')
            {
                while (true)
                {
                    i++;
                    tokenPart = expression[i];
                    if (tokenPart == '(')
                    {
                        braketCount++;
                    }
                    if (tokenPart == ')')
                    {
                        braketCount--;
                    }
                    powSqrtString += tokenPart;

                    if (braketCount == 0)
                    {
                        break;
                    }
                }
                outputStack.Push(Math.Sqrt(powSqrtString.CalculateExpression()).ToString());
                continue;
            }


            while (char.IsDigit(tokenPart) || tokenPart == '.')
            {
                currentToken += tokenPart;
                i++;
                tokenPart = expression[i];
            }

            if (currentToken.Length > 0)
            {
                outputStack.Push(currentToken);
            }

            if (operatorStack.Count > 0)
            {
                currentIndex = OperatorIndex(tokenPart);
                lastOperator = (char)operatorStack.Peek();
                lastIndex = OperatorIndex(lastOperator);

                if (currentIndex == lastIndex && lastOperator != '(')
                {
                    outputStack.Push(lastOperator);
                    operatorStack.Pop();
                    operatorStack.Push(tokenPart);
                }
                else if (currentIndex == lastIndex && lastOperator == '(')
                {
                    operatorStack.Push(tokenPart);
                }
                else if (currentIndex < lastIndex && lastOperator != '(')
                {
                    outputStack.Push(operatorStack.Pop());
                    operatorStack.Push(tokenPart);
                }
                else if (currentIndex == 6)
                {
                    do
                    {
                        if (lastOperator == 40)
                        {
                            break;
                        } 
                        outputStack.Push((char)operatorStack.Pop());
                        lastOperator = (char)operatorStack.Peek();
                        lastIndex = OperatorIndex(lastOperator);
                    } while (lastIndex != 5);
                    operatorStack.Pop();
                }
                else
                {
                    operatorStack.Push(tokenPart);
                }
            }
            else
            {
                operatorStack.Push(tokenPart);
            }
        }

        while (operatorStack.Count > 0)
        {
            outputStack.Push((char)operatorStack.Pop());
        }
        return outputStack;
    }

    private static int OperatorIndex(char tokenPart)
    {
        int value;
        operators.TryGetValue(tokenPart.ToString(), out value);
        return value;
    }

    private static string PrepareExpression(string expression)
    {
        expression = expression.Replace(" ", "");
        expression = expression.Replace("sqrt", "s");
        expression = expression.Replace("pow", "p");
        return expression;
    }
}