using System;
using System.Text;

class ExtractURL
{
    static void Main()
    {
        string input = "http://www.devbg.org/forum/index.php";

        string protocol = "";
        string server = "";
        string resource = "";

        int startIndex = 0;

         startIndex = input.IndexOf("://", startIndex);
        protocol = input.Substring(0, startIndex);
         startIndex = startIndex + 3;
        server = input.Substring(startIndex, input.IndexOf("/", startIndex) - startIndex);
         int used = input.Length - protocol.Length - server.Length + 1;
        resource = input.Substring(used, input.Length - used);

        Console.WriteLine("Protocol: {0}", protocol);
        Console.WriteLine("Server: {0}", server);
        Console.WriteLine("Resource: {0}", resource);
    }
}