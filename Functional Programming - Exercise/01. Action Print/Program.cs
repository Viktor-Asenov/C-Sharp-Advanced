using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();

            Action<string> print = new Action<string>(Program.Print);

            names.ForEach(print);
        }

        static void Print(string name)
        {
            Console.WriteLine($"Sir {name}");
        }
    }
}
