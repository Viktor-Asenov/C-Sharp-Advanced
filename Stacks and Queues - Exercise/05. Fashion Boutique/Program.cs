using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacityRack = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(clothes);
            int sumClothes = 0;
            int countRacks = 1;

            while (stack.Count > 0)
            {
                sumClothes += stack.Peek();

                if (sumClothes <= capacityRack)
                {
                    stack.Pop();
                }
                else
                {
                    countRacks++;
                    sumClothes = 0;
                }
            }

            Console.WriteLine(countRacks);
        }
    }
}
