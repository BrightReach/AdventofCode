using System;
using System.IO;

namespace Day_3
{
    class Program
    {
        public static int TreeCounter(int x_slope, int y_slope)
        {
            string[] map_data = File.ReadAllLines("day3.txt");
            char map_icon = '#';
            int map_width = map_data[0].Length;
            int x = 0, tree_count = 0;
            for (int y = 0; y < map_data.Length; y += y_slope){
                if (y % y_slope != 0)
                    continue;
                char[] map = map_data[y].ToCharArray();
                if(map_icon == map[x]){
                    tree_count++;
                }
                x = (x + x_slope) % map_width;
            }
            return tree_count;
        }

        public static void Main()
        {
            long a, b, c, d, e;
            a = TreeCounter(1, 1);
            b = TreeCounter(3, 1);
            c = TreeCounter(5, 1);
            d = TreeCounter(7, 1);
            e = TreeCounter(1, 2);
            Console.WriteLine($"{a} * {b} * {c} * {d} * {e} = {a*b*c*d*e}");

        }

    }
}
