//Write a program that removes from a text file all words listed
//in given another text file. Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

class ReplaceWordsFromGivenFile
{
    static void Main()
    {
        string[] words;
        string inputPath = "input.txt";
        string tempOutputPath = "__temp000.txt";
        string textInput;
        string currentLine = "";

        try
        {
            CreateFile("words-list.txt", "Lorem test elit quis Excepteur sint occaecat cupidatat");

            using (StreamReader wordsList = new StreamReader("words-list.txt"))
            {
                words = Regex.Split(wordsList.ReadToEnd(), @"\s+");
            }

            CreateFile(inputPath,
@"Lorem ipsum dolor sit amet, consectetur adipisicing elit,
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut 
aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit
esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident,
sunt in culpa qui officia deserunt mollit anim id est laborum");

            using (StreamReader inputStream = new StreamReader(inputPath))
            {
                using (StreamWriter tempOutput = new StreamWriter(tempOutputPath))
                {
                    while ((textInput = inputStream.ReadLine()) != null)
                    {
                        currentLine = Regex.Replace(textInput, @"\b(" + string.Join("|", words) + @")\b", "");
                        tempOutput.WriteLine(currentLine);
                    }
                }
            }

            File.Delete(inputPath);
            File.Copy(tempOutputPath, inputPath);
            File.Delete(tempOutputPath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("String path is null");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path is a zero-length string or contains invalid characters");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum lenght");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found");
        }
        catch (IOException)
        {
            Console.WriteLine("I/O error");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don`t have permission to access this file");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Invalid path format");
        }
    }

    private static void CreateFile(string inputPath, string input)
    {
        using (StreamWriter createFile = new StreamWriter(inputPath))
        {
            createFile.Write(input);
        }
    }
}