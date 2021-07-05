using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var listNums = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            int countNums = listNums.Count;
            int sum = listNums.Sum();

            Console.WriteLine(countNums);
            Console.WriteLine(sum);
        }
    }
}
