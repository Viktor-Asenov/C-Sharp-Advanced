using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());

            var circle = new Queue<string>();

            for (int i = 0; i < petrolPumps; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                circle.Enqueue(input);
            }

            int totalFuel = 0;

            for (int i = 0; i < petrolPumps; i++)
            {
                string currentInfo = circle.Dequeue();
                var splitted = currentInfo.Split().Select(int.Parse).ToArray();

                var fuel = splitted[0];
                var distance = splitted[1];
                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i = -1;
                }

                circle.Enqueue(currentInfo);
            }

            var firstElement = circle.Dequeue().Split();
            Console.WriteLine(firstElement[2]);
        }
    }
}
