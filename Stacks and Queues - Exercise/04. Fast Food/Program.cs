using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFoodAvailable = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queueOrders = new Queue<int>(orders);

            Console.WriteLine(queueOrders.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                int currentOrder = orders[i];

                if (quantityFoodAvailable >= currentOrder)
                {
                    quantityFoodAvailable -= queueOrders.Dequeue();
                }
                else
                {
                    if (queueOrders.Count == 1)
                    {
                        Console.WriteLine($"Orders left: {queueOrders.Dequeue()}");
                        return;
                    }
                    else
                    {
                        queueOrders.ToString();
                        Console.WriteLine($"Orders left: {string.Join(" ", queueOrders)}");
                        return;
                    }
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
