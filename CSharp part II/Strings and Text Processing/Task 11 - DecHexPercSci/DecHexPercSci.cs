using System;

class DecHexPercSci
{
    static void Main()
    {
        Console.Write("Number = ");
        int number = int.Parse(Console.ReadLine());
        
        string[,] result = new string[4,2];
        result[0,0] = "decimal";
        result[0,1] = string.Format("{0,15}",number);
        result[1,0] = "hexadecima";
        result[1,1] = string.Format("{0,15:X}",number);
        result[2,0] = "percent";
        result[2,1] = string.Format("{0,15:P}",number/100f);
        result[3,0] = "scientific";
        result[3,1] = string.Format("{0,15:E}",number);

        for (int i = 0; i < 4; i++)
			{
			    Console.WriteLine("{0,10} = {1}",result[i,0], result[i,1]);
			}
    }
}