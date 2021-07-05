using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        long[] numbers = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

        Comparer<long> evenOddSorter = Comparer<long>.Create((x1, x2) =>
        {
            if (Math.Abs(x1) % 2 == 0 && Math.Abs(x2) % 2 != 0)
                return -1;
            else if (Math.Abs(x1) % 2 != 0 && Math.Abs(x2) % 2 == 0)
                return 1;
            else
                return x1.CompareTo(x2);
        });


        Array.Sort(numbers, evenOddSorter);

        Console.WriteLine(String.Join(" ", numbers));
    }
}