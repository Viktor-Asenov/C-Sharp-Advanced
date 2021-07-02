using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] currentData = Console.ReadLine().Split(" -> ").ToArray();
                string[] splittedParts = currentData[1].Split(',');
                string color = currentData[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int j = 0; j < splittedParts.Length; j++)
                {
                    string currentItem = splittedParts[j];

                    if (!wardrobe[color].ContainsKey(currentItem))
                    {
                        wardrobe[color][currentItem] = 0;
                    }

                    wardrobe[color][currentItem]++;
                }
            }

            string[] searchedItem = Console.ReadLine().Split();
            string itemColor = searchedItem[0];
            string item = searchedItem[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == itemColor && cloth.Key == item)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
