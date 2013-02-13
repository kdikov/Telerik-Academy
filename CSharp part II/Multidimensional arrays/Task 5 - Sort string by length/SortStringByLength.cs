using System;
using System.Linq;

class SortStringByLength
{
    static void Main()
    {
        string[] array = { "aaa", "aa", "aaaa", "aaaaa", "0" };
        
        /*
        var sorted = array.OrderBy(x => x.Length);
        foreach (var element in sorted)
        {
            Console.WriteLine(element);
        }
        */

        Array.Sort(array, (x, y) => (x.Length).CompareTo(y.Length));
        foreach (string element in array)
        {
            Console.WriteLine(element);
        }
    }
}