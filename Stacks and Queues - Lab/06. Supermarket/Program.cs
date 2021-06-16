using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Paid")
                {
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer);                        
                    }

                    customers.Clear();
                    continue;
                }
                else if (input == "End")
                {
                    Console.WriteLine($"{customers.Count} people remaining.");
                    break;
                }

                customers.Enqueue(input);
            }
        }
    }
}
