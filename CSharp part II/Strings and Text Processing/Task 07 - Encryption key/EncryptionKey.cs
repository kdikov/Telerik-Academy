using System;
using System.Text;

class EncryptionKey
{
    static void Main()
    {
        string input = "Test string for encryption";
        Console.WriteLine("Input string: {0}", input);

        string key = "2462Z";

        //Encrypt
        int keyIndex = 0;
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            output.Append((char)(input[i] ^ key[keyIndex]));

            if (keyIndex == key.Length - 1)
            {
                keyIndex = 0;
            }
            else
            {
                keyIndex++;
            }
        }

        Console.WriteLine(@"Encoded string: {0}", output);
        input = output.ToString();

        // Reverse encryption
        output.Clear();
        keyIndex = 0;
        for (int i = 0; i < input.Length; i++)
        {
            output.Append((char)(input[i] ^ key[keyIndex]));

            if (keyIndex == key.Length - 1)
            {
                keyIndex = 0;
            }
            else
            {
                keyIndex++;
            }
        }
        Console.WriteLine("Decoded string: {0}", output);
    }
}
