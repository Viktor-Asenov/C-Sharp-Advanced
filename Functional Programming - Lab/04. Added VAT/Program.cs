using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Added_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(p => p + p * 0.2)
                .ToList();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
