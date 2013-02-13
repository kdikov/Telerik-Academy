using System;

class SetCombinations
{
    static int[] combination;
    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int K = int.Parse(Console.ReadLine());

        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            arr[i] = i + 1;
        }

        combination = new int[K];
        Combinations(0, 0, N, K, arr);
    }

    static void Combinations(int currentIndex, int count, int N, int K, int[] arr)
    {
        if (currentIndex == K)
        {
            Console.WriteLine("{" + string.Join(", ", combination) + "}");
        }
        else
        {
            for (int j = count; j < N; j++)
            {
                combination[currentIndex] = arr[j];
                Combinations(currentIndex + 1, j + 1, N, K, arr);
            }
        }
    }
}