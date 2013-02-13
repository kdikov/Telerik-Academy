using System;

class SetVariations
{
    static int[] variation;
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

        variation = new int[K];
        Variations(0, arr, K);
    }

    private static void Variations(int count, int[] arr, int K)
    {
        if (count < K)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                variation[count] = arr[i];
                Variations(count + 1, arr, K);
            }
        }
        else
        {
            Console.WriteLine("{" + string.Join(", ", variation) + "}");
        }
    }
}