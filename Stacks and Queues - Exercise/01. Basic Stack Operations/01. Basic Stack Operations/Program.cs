using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            int elementsForPushing = operations[0];
            int elementsToPop = operations[1];
            int element = operations[2];

            for (int j = 0; j < nums.Length; j++)
            {
                stack.Push(nums[j]);
            }

            if (stack.Count >= elementsToPop)
            {
                for (int k = 0; k < elementsToPop; k++)
                {
                    stack.Pop();
                }

                if (stack.Count <= 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }            

            if (stack.Contains(element))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
