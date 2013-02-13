//Write a program that deletes from given text file all odd lines.
//The result should be in the same file.

using System;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        string inputPath = "test.txt";
        CreateFile(inputPath);
        string tempFile = "__temp000.txt";

        using (StreamReader inputStream = new StreamReader(inputPath))
        {
            using (StreamWriter tempOutput = new StreamWriter(tempFile))
            {
                string textInput;
                int count = 1;
                while ((textInput = inputStream.ReadLine()) != null)
                {
                    if (count % 2 == 0)
                    {
                        tempOutput.WriteLine(textInput);
                    }
                    count++;
                }
            }
        }

        File.Delete(inputPath);
        File.Copy(tempFile, inputPath);
        File.Delete(tempFile);

    }

    private static void CreateFile(string inputPath)
    {
        using (StreamWriter createFile = new StreamWriter(inputPath))
        {
            createFile.WriteLine("01 Some text");
            createFile.WriteLine("02 Some text");
            createFile.WriteLine("03 Some text");
            createFile.WriteLine("04 Some text");
        }
    }
}