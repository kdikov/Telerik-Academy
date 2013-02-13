//Write a program that compares two text files line by line 
//and prints the number of lines that are the same and the 
//number of lines that are different. Assume the files have equal number of lines.

using System;
using System.Text;
using System.IO;

class CompareFiles
{
    static void Main()
    {
        string path_1 = "file1.txt";
        string path_2 = "file2.txt";

        int sameLines = 0;
        int allLines = 0;

        using (StreamReader file1 = new StreamReader(path_1))
        {
            using (StreamReader file2 = new StreamReader(path_2))
            {
                string line = null;
                // read line from file1
                while ( (line = file1.ReadLine()) != null ) 
                {
                    // read line from file2 and compare the strings 
                    // return values from string.Compare -1, 0 or 1 (0 for identical strings)
                    if (string.Compare(line, file2.ReadLine()) == 0 )
                    {
                        sameLines++;
                    }
                    allLines++;
                }
            }
        }

        Console.WriteLine("Number of same lines: {0}", sameLines);
        Console.WriteLine("Number of different lines: {0}", allLines - sameLines);
    }
}