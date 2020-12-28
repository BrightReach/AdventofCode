using System;
using System.IO;

class Program
{
    public static void Main()
    {
        try
        {
                string[] raw_data = File.ReadAllLines("day1.txt");
                int[] data = Array.ConvertAll(raw_data, int.Parse);

                for (int i = 0; i < data.Length; i++)
                {
                    for (int m = 0; m < data.Length; m++)
                    {
                        if ((data[i] + data[m]) == 2020)
                            {Console.WriteLine("!!WINNER!! WINNING NUMBER " + data[i] + " X " + data[m] + " = " + (data[i] * data[m]));
                            return;}
                        else
                            Console.WriteLine("loser...");
                    }
                }
            
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}