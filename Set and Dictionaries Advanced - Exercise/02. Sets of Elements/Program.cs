using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = sets[0];
            int m = sets[1];            

            HashSet <decimal> firstSet = new HashSet<decimal>();
            HashSet<decimal> secondSet = new HashSet<decimal>();

            for (int i = 0; i < n; i++)
            {
                decimal currentNum = decimal.Parse(Console.ReadLine());
                firstSet.Add(currentNum);
            }

            for (int j = 0; j < m; j++)
            {
                decimal currentNum = decimal.Parse(Console.ReadLine());
                secondSet.Add(currentNum);
            }

            firstSet.IntersectWith(secondSet);

            if (secondSet.Count > 0)
            {
                Console.WriteLine(string.Join(" ", firstSet));
            }            
        }
    }
}
