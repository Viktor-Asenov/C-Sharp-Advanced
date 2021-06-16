using System;
using System.Collections.Generic;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stack = new Stack<char>(input);

            foreach (var symbol in stack)
            {
                Console.Write(symbol);
            }
        }
    }
}
