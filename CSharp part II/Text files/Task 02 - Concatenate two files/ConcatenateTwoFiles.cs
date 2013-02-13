//Write a program that concatenates 
//two text files into another text file.

using System;
using System.IO;
using System.Diagnostics;
class ConcatenateTwoFiles
{
    static void Main()
    {
        string path_1 = "first-file.txt";
        string path_2 = "second-file.txt";
        string newFilePath = "new-file.txt";

        using (StreamReader firstFile = new StreamReader(path_1))
        {
            using (StreamReader secondFile = new StreamReader(path_2))
            {
                string newFile = firstFile.ReadToEnd() + secondFile.ReadToEnd();
                using (StreamWriter thirdFile = new StreamWriter(newFilePath))
                {
                    thirdFile.Write(newFile);
                }
                Process.Start("new-file.txt");
            }
        }
    }
}