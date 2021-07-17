using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Warm_Winter
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] hats = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] scarfs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfHats = new Stack<int>(hats);
            Queue<int> queueOfScarfs = new Queue<int>(scarfs);
            List<int> sets = new List<int>();
            
            while (stackOfHats.Count > 0 && queueOfScarfs.Count > 0)
            {
                int currentHat = stackOfHats.Peek();
                int currentScarf = queueOfScarfs.Peek();
                int priceCurrentSet = currentHat + currentScarf;

                if (currentHat > currentScarf)
                {
                    stackOfHats.Pop();
                    queueOfScarfs.Dequeue();
                    sets.Add(priceCurrentSet);
                }
                else if (currentScarf > currentHat)
                {
                    stackOfHats.Pop();
                }
                else
                {
                    queueOfScarfs.Dequeue();
                    int currentHatValue = stackOfHats.Pop();
                    currentHatValue++;
                    stackOfHats.Push(currentHatValue);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
