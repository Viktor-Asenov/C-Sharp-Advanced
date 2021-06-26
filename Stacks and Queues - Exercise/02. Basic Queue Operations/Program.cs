using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            int elementsForPushing = operations[0];
            int elementsToPop = operations[1];
            int element = operations[2];

            for (int j = 0; j < nums.Length; j++)
            {
                queue.Enqueue(nums[j]);
            }

            if (queue.Count >= elementsToPop)
            {
                for (int k = 0; k < elementsToPop; k++)
                {
                    queue.Dequeue();
                }

                if (queue.Count <= 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            if (queue.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
