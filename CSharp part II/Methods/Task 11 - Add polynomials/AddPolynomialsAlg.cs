/*
 *  11.Write a method that adds two polynomials. 
 *  Represent them as arrays of their coefficients as in the example below:
 *
 *  x^2 + 5 = 1x^2 + 0x + 5 -> 5 0 1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AddPolynomialsAlg
{
    static void Main()
    {
        decimal[] firstPolynomial = new decimal[]  { 2, 6, -3 };
        decimal[] secondPolynomial = new decimal[] { 1, 2, 0, -3 };

        decimal[] newPolynomial = AddPolynomials(firstPolynomial, secondPolynomial);

        Console.Write("First polynomial: ");
        PrintPolynomial(firstPolynomial);
        Console.Write("\nSecond polynomial: ");
        PrintPolynomial(secondPolynomial);

        Console.Write("\n\nResult: ");
        PrintPolynomial(newPolynomial);
        Console.WriteLine();
    }

    private static void PrintPolynomial(decimal[] polynomial)
    {
        StringBuilder returnString = new StringBuilder();

        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (polynomial[i] != 0)
            {
                returnString.Append(polynomial[i] > 0 ? " + " : " - ");
                returnString.Append(Math.Abs(polynomial[i]));
                if (i != 0)
                {
                    returnString.Append(i > 1 ? "x^" + i : "x");
                }
            }
        }

        if (returnString[1] != '-')
        {
            returnString.Remove(0, 3);
        }
        else
        {
            returnString.Remove(0, 1);
        }

        Console.Write(returnString);
    }

    private static decimal[] AddPolynomials(decimal[] firstPolynomial, decimal[] secondPolynomial)
    {
        decimal[] newPolynomial = new decimal[Math.Max(firstPolynomial.Length, secondPolynomial.Length)];

        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            newPolynomial[i] = firstPolynomial[i];
        }

        for (int i = 0; i < secondPolynomial.Length; i++)
        {
            newPolynomial[i] = newPolynomial[i] + secondPolynomial[i];
        }

        return newPolynomial;
    }
}