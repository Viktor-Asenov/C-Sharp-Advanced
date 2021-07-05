using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToList();

            Predicate<string> validNames = x => x.Length <= lenght;

            names = names.FindAll(validNames).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
