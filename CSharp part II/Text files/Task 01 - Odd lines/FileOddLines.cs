//Write a program that reads a text file
//and prints on the console its odd lines.

using System;
using System.IO;

class FileOddLines
{
    static void Main()
    {
        string line = null;
        string path = "..\\..\\FileOddLines.cs";
        using (StreamReader file = new StreamReader(path))
        {
            int count = 1;

            while ( (line = file.ReadLine()) != null)
            {
                if (count % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                count++;
            }    
        }
        
    }
}