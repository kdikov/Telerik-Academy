//Write a program that deletes from a text file all 
//words that start with the prefix "test".
//Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;
using System.Text.RegularExpressions;

class ClassName
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
                    tempOutput.WriteLine(Regex.Replace(textInput, @"\btest\w*", ""));
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
            createFile.WriteLine("Test file for replacing words starting with \"test\"");
            createFile.WriteLine("teststart starttest {test} \"test0\" _test");
        }
    }
}