using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] startEnd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = startEnd[0];
            int end = startEnd[1];
            string condition = Console.ReadLine();

            Predicate<int> findEven = number => number % 2 == 0;

            for (int i = start; i <= end; i++)
            {
                if (findEven(i) && condition == "even")
                {
                    Console.Write($"{i} ");
                }
                else if (findEven(i) == false && condition == "odd") 
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
