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

                Console.WriteLine("Searching...");
                for (int i = 0; i < data.Length; i++)
                {
                    for (int m = 0; m < data.Length; m++)
                    {
                        for (int j = 0; j <data.Length; j++)
                        {
                            if ((data[i] + data[m] + data[j]) == 2020)
                            {Console.WriteLine("!!WINNER!! WINNING NUMBER " + data[i] + " X " + data[m] + " X " + data[j] + " = " + (data[i] * data[m] * data[j]));
                            }
                        }
                        if ((data[i] + data[m]) == 2020)
                            {Console.WriteLine("!!WINNER!! WINNING NUMBER " + data[i] + " X " + data[m] + " = " + (data[i] * data[m]));
                            return;
                            }
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