using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Another
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

            for (int i = clothes.Length - 1; i >= 0; i--)
            {
                sumClothes += clothes[i];

                if (sumClothes <= capacityRack)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }                
                else
                {
                    i++;
                    countRacks++;
                    sumClothes = 0;
                }
            }

            Console.WriteLine(countRacks);
        }
    }
}
