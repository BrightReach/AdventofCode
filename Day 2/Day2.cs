using System;
using System.IO;

class Program
{
    public static void Main() {
        string[] raw_data = File.ReadAllLines("day2.txt");
        char[] delimiterChars = new char[] { ' ', ':', '-' };
        int minCount, maxCount, letterCount, posCount, successCount, newCount, index;
        string password;
        successCount, newCount = 0;

        for (int i = 0; i < raw_data.Length; i++)
        {
            string[] sequence = raw_data[i].Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            char charCode = char.Parse(sequence[2]);
            minCount = int.Parse(sequence[0]);
            maxCount = int.Parse(sequence[1]);
            password = sequence[3];
            posCount = 0;
            letterCount = 0;
            index = 1;

            foreach (char letter in password)
                {
                    if (letter == charCode){
                        letterCount++;
                        
                        if(index == minCount || index == maxCount)
                            posCount++;
                        }
                            
                    index++;
                }

            if (letterCount <= maxCount && letterCount >= minCount)
                 successCount++;
            if (posCount == 1)
                newCount++;
            }

            Console.WriteLine($"There are {successCount} passed passwords out of {raw_data.Length}. And there are {newCount} passed passwords under the new policy.");

    }
}