//Write a program that reads a list of words from a
//file words.txt and finds how many times each of the
//words is contained in another file test.txt. 
//The result should be written in the file result.txt and the words 
//should be sorted by the number of their occurrences in descending order. 
//Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

class SortRepeatingWords
{
    public class Word
    {
        public int count;
        public string word;

        public Word(string word)
        {
            this.word = word;
        }
    }

    static void Main()
    {
        string[] words;
        string inputPath = "input.txt";
        string outputPath = "result.txt";
        string wordsPath = "words.txt";
        string textInput;
        List<Word> wordsList = new List<Word>();

        try
        {
            using (StreamReader wordListFile = new StreamReader(wordsPath))
            {
                words = Regex.Split(wordListFile.ReadToEnd(), @"\s+");
            }

            foreach (var word in words)
            {
                wordsList.Add(new Word(word));
            }
            using (StreamReader inputStream = new StreamReader(inputPath))
            {
                textInput = inputStream.ReadToEnd();

                for (int i = 0; i < wordsList.Count; i++)
                {
                    wordsList[i].count = Regex.Matches(textInput, @"\b" + wordsList[i].word + @"\b").Count;
                }
            }

            wordsList.Sort((x,y) => y.count.CompareTo(x.count));

            using (StreamWriter output = new StreamWriter(outputPath))
            {
                foreach (var item in wordsList)
                {
                    output.WriteLine(item.word + " " + item.count);
                }
            }

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