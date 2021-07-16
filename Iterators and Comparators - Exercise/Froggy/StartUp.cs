using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake<int> lake = new Lake<int>(stones);
            List<int> frogPath = new List<int>();
            

            for (int i = 0; i < lake.Stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    frogPath.Add(lake.Stones[i]);
                }
            }

            for (int i = lake.Stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    frogPath.Add(lake.Stones[i]);
                }
            }

            Console.WriteLine(string.Join(", ", frogPath));
        }
    }
}
