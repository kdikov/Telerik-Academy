using System;

class LetterCount
{
    static void Main()
    {
        string input = "This is a test input for counting letters.";
        int startIndex = 'A';
        int endIndex = 'z';
        int[] letters = new int[endIndex - startIndex + 1];

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] >= startIndex && input[i] <= endIndex)
            {
                letters[input[i] - startIndex]++;
            }
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] > 0)
            {
                Console.WriteLine("Letter {0} is found {1} times.", (char)(i+'A'), letters[i]);
            }
        }
    }
}