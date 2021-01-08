using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Day_4
{
    class Program
    {
        bool ValidField (string fields)
        {
            string[] pair = fields.Split(':');
            string value = pair[1];
            int digit = int.Parse(value);

            switch (pair[0])
            {
                case "byr":
                    if (value.Length != 4)
                        return false;
                    if(digit >= 1920 && digit <= 2002)
                        return true;
                    break;
                case "iyr":
                    if (value.Length != 4)
                        return false;
                    if(digit >= 2010 && digit <= 2020)
                        return true;
                    break;
                case "eyr":
                    if (value.Length != 4)
                        return false;
                    if(digit >= 2020 && digit <= 2030)
                        return true;
                    break;
                case "hgt":
                    Match height = Regex.Match(value, "([0-9]*)(cm|in)");
                    if(Regex.IsMatch(value, "([0-9]*)(cm|in)"))
                    {
                        string measurement = height.Groups[2].ToString();
                        int height_val = int.Parse(height.Groups[1].ToString());
                        if (measurement == "in")
                            if(height_val >= 59 && height_val <= 76)
                                return true;
                        else if (measurement == "cm")
                            if (height_val >= 150 && height_val <= 193)
                                return true;
                    }
                    break;
                case "hcl":
                    Regex reg = new Regex("#[0-9a-fA-F]{6}");
                    if (reg.IsMatch(value))
                        return true;
                    break;
                case "ecl":
                    if (value.Length != 3)
                        return false;
                    if(Regex.IsMatch(value, "amb|blu|brn|gry|grn|hzl|oth"))
                        return true;
                    break;
                case "pid":
                    if (value.Length != 9)
                        return false;
                    if (int.TryParse(value, out int results))
                        return true;
                    break;
                case "cid":
                    return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string raw_data = File.ReadAllText("day4.txt");
            string first_pass = Regex.Replace(raw_data, "\n\n", "YAZZI");
            string second_pass = Regex.Replace(first_pass, "\n", " ");
            string[] passport = second_pass.Split("YAZZI");
            int counter = 0;
            foreach (var entry in passport)
            {
                string[] field = entry.Split(' ');
                if (field.Length == 8 || field.Length == 7 && entry.IndexOf("cid") == -1)
                    if(field.All(m => ValidField(m.ToString())))
                        counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
