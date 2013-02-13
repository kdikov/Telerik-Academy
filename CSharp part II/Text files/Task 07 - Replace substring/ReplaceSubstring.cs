//Write a program that replaces all occurrences of the substring "start"
//with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;

class ReplaceSubstrings
{
    static void Main()
    {
        string inputPath = "input.txt";
        CreateFile(inputPath);
        string[] patterns = {"start", "finish"};
        string textInput;
        
        StringBuilder outputString = new StringBuilder();

        Console.WriteLine("Input text:\n");
        using (StreamReader inputStream = new StreamReader(inputPath))
        {
            using (StreamWriter tempOutput = new StreamWriter("__temp999.txt"))
            {
                while ((textInput = inputStream.ReadLine()) != null)
                {
                    Console.WriteLine(textInput);
                    int startIndex = 0;
                    int endIndex = 0;

                    while (true)
                    {
                        startIndex = textInput.IndexOf(patterns[0], endIndex);
                        if (startIndex < 0)
                        {
                            outputString.Append(textInput.Substring(endIndex, textInput.Length - endIndex));
                            break;
                        }
                        outputString.Append(textInput.Substring(endIndex, startIndex - endIndex));
                        outputString.Append(patterns[1]);
                        endIndex = startIndex + patterns[0].Length;
                    }
                }
                tempOutput.Write(outputString);
            }
        }

        File.Delete(inputPath);
        File.Copy("__temp999.txt", inputPath);
        File.Delete("__temp999.txt");

        Console.WriteLine("\nOutput text:\n");
        Console.WriteLine(outputString);
    }

    private static void CreateFile(string inputPath)
    {
        using (StreamWriter createFile = new StreamWriter(inputPath))
        {
            createFile.Write("Test file for replacing substring start with substring finish");
            createFile.Write("Teststart starttest {start} \"start\" 123start123");
        }
    }
}