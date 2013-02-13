using System;
using System.Text;

class StringToUnicode
{
    static void Main()
    {
        string input = "Hi!";
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            output.Append("\\u");
            output.Append(Convert.ToString((int)input[i],16).PadLeft(4,'0'));
        }

        Console.WriteLine(output);
    }
}