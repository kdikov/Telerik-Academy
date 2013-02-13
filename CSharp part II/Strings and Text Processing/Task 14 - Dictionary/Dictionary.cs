using System;
using System.Text;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        string[] dData = {
            ".NET - platform for applications from Microsoft",
            "CLR - managed execution environment for .NET",
            "namespace - hierarchical - organization of classes"
        };

        int separatorIndex = 0;
        for (int i = 0; i < dData.Length; i++)
        {
            separatorIndex = dData[i].IndexOf(" - ");
            dictionary.Add(dData[i].Substring(0, separatorIndex), dData[i].Substring(separatorIndex + 3, dData[i].Length - separatorIndex - 3));
        }
        Console.Write("Enter word: ");
        string result = "";
        dictionary.TryGetValue(Console.ReadLine(), out result);
        Console.WriteLine(result);
    }
}