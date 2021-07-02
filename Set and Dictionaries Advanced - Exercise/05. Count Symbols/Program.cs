using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            var symbols = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (!symbols.ContainsKey(currentChar))
                {
                    symbols[currentChar] = 0;
                }

                symbols[currentChar]++;
            }

            var sortedSymbols = symbols.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var symbol in sortedSymbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
