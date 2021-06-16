using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();

            var queue = new Queue<string>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.Parse(numbers[i]) % 2 == 0)
                {
                    queue.Enqueue(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
