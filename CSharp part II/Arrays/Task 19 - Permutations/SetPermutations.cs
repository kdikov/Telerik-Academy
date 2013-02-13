using System;
using System.Collections.Generic;

class SetPermutations
{
    static int count;
    static List<int> numbers = new List<int>();
    static HashSet<HashSet<int>> permutations = new HashSet<HashSet<int>>();
    static HashSet<int> permotation = new HashSet<int>();

    static void Main()
    {
        Console.Write("N = ");
        count = int.Parse(Console.ReadLine());

        for (int i = 1; i <= count; i++)
			{
			    numbers.Add(i);
			}

        HashSet<int> empty = new HashSet<int>();
        Permutations(count, empty, numbers[0]);

        foreach (var set in permutations)
        {
            Console.WriteLine("{" + string.Join(", ", set) + "}");
        }
    }

    private static void Permutations(int currentCount, HashSet<int> set, int number)
    {
        if (currentCount > 0)
        {
            for (int i = 0; i < count; i++)
            {
                permotation = new HashSet<int>();
                permotation.UnionWith(set);
                permotation.Add(numbers[i]);
                Permutations(currentCount - 1, permotation, numbers[i]);
            }
        }

        if(permotation.Count == count)
        {
            permutations.Add(permotation);
        }
    }
}