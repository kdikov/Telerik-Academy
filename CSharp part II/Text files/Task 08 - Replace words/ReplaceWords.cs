//Write a program that replaces all occurrences of the word "start"
//with the word "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceSubstrings
{
    static void Main()
    {
        string inputPath = "input.txt";
        CreateFile(inputPath);
        string[] patterns = { "start", "finish" };
        string textInput;

        using (StreamReader inputStream = new StreamReader(inputPath))
        {
            using (StreamWriter tempOutput = new StreamWriter("__temp000.txt"))
            {
                while ((textInput = inputStream.ReadLine()) != null)
                {
                    tempOutput.WriteLine(Regex.Replace(textInput, @"\bstart\b", "finish"));
                }
            }
        }

        File.Delete(inputPath);
        File.Copy("__temp000.txt", inputPath);
        File.Delete("__temp000.txt");

    }

    private static void CreateFile(string inputPath)
    {
        using (StreamWriter createFile = new StreamWriter(inputPath))
        {
            createFile.WriteLine("Test file for replacing substring start with substring finish");
            createFile.WriteLine("Teststart starttest {start} \"start\" 123start123");
        }
    }
}