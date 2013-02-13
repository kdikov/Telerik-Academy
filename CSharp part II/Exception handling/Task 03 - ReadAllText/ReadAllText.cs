// 3.Write a program that enters file name along with
// its full file path (e.g. C:\WINDOWS\win.ini), reads its 
// contents and prints it on the console. Find in MSDN how to
// use System.IO.File.ReadAllText(…). Be sure to catch all possible
// exceptions and print user-friendly error messages.

using System;
using System.IO;

class ReadAllText
{
    static void Main()
    {
        string filePath = "C:\\Windows\\win.ini";

        try
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine(fileContent);
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
}