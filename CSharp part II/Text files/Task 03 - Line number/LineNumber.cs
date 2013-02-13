//Write a program that reads a text file and inserts line numbers 
//in front of each of its lines. The result should be written to another text file.

using System;
using System.IO;
using System.Diagnostics;
class LineNumber
{
    static void Main()
    {
        //creating file;
        string file = "test.txt";
        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine("Some text");
            output.WriteLine("Some text");
            output.WriteLine("Some text");
            output.WriteLine("Some text");
        }

        //reading file and creating the new file;
        string outputFile = "text-with-lines.txt";
        using (StreamWriter output = new StreamWriter(outputFile))
        {
            using (StreamReader input = new StreamReader(file))
            {
                string line = null;
                int linesCount = 1;
                while ( (line = input.ReadLine()) != null )
                {
                    output.WriteLine("[" + linesCount + "]" + line);
                    linesCount++;
                }
            }
        }

        Process.Start(outputFile);
    }
}