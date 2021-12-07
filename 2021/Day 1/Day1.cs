using System;
using System.IO;

class Program
{
    public static void Main()
    {
        try
        {
            string[] raw_data = File.ReadAllLines("input.txt");
            int[] data = Array.ConvertAll(raw_data, int.Parse);
            int highest, previous, counter;
            highest = 0;
            previous = 0;
            counter = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (i != 0)
                {
                    if (data[i] > previous)
                    {
                        Console.WriteLine($"{i} {data[i]} is higher than {previous}!");
                        previous = data[i];
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($"{data[i]} is lower than {previous}!");
                        previous = data[i];
                    }
                }
                else
                {
                    previous = data[i];
                    Console.WriteLine($"{i} And we're starting with {previous} being the first and highest!");
                }
            }
            Console.WriteLine($"We've counted the highest {counter} times!");

        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}