//Write a program that downloads a file from Internet 
//(e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. 
//Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Text;

class DownloadFile
{
    static void Main()
    {
        string url = @"http://greensurrealism.pbworks.com/f/body.jpg";
        string[] getFileName = url.Split('/');
        string outputFileName = getFileName[getFileName.Length - 1];
        int dotIndex = outputFileName.LastIndexOf('.');
        
        bool toDownload = false;
        string fileName = "";
        string fileNameExtension = "";
        if (dotIndex != -1)
        {
            fileName = outputFileName.Substring(0, dotIndex);
            fileNameExtension = outputFileName.Substring(dotIndex + 1, outputFileName.Length - dotIndex - 1);
            toDownload = true;
        }
        
        DrawLine();
        if (File.Exists(outputFileName) && toDownload)
        {
            Console.WriteLine("There is a file with that name.");
            Console.WriteLine("1) Overwrite the file");
            Console.WriteLine("2) Add postfix to the filename");
            Console.WriteLine("3) Cancel download");
            DrawLine();
            Console.Write("Your choice (1,2 or 3): ");
            int choice = int.Parse(Console.ReadLine());

            int postfix = 1;
            switch (choice)
            {
                case 1:
                    DrawLine();
                    Console.Write("Are you sure you want to delete {0}? (y/n): ", outputFileName);
                    string deleteAnswear = Console.ReadLine();
                    if (deleteAnswear == "y")
                    {
                        File.Delete(outputFileName);
                    }
                    if (deleteAnswear == "n")
                    {
                        toDownload = false;
                    }
                    break;
                case 2:
                    while (File.Exists(fileName + "[" + postfix + "]." + fileNameExtension))
                    {
                        postfix++;
                    }
                    outputFileName = fileName + "[" + postfix + "]." + fileNameExtension;
                    break;
                default:
                    toDownload = false;
                    break;
            }
        }

        if (toDownload)
        {
            using (WebClient download = new WebClient())
            {
                try
                {
                    download.DownloadFileAsync(new Uri(url), outputFileName);
                    download.DownloadProgressChanged += progress;
                    while (download.IsBusy)
                    {
                        Thread.Sleep(5);
                    }
                    Thread.Sleep(50);
                    Console.WriteLine();
                    Console.WriteLine("Downloading completed");
                    DrawLine();
                    Console.Write("Open file? (y/n): ");
                    string openFile = Console.ReadLine();
                    if (openFile == "y")
                    {
                        Process.Start(outputFileName);
                    }
                }
                catch (WebException)
                {
                    Console.WriteLine("Some exception");
                }
                finally
                {
                    download.Dispose();
                }
            }

        }
    }

    private static void DrawLine()
    {
        Console.WriteLine("==================================================");
    }

    private static void progress(object sender, DownloadProgressChangedEventArgs e)
    {
        Console.Write("\rDownloading: {0:000} %", e.ProgressPercentage);
    }
}