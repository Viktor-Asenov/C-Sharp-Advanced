using System;
using System.Collections.Generic;

namespace _08._Trafic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            var queue = new Queue<string>();
            int count = 0;

            while (command != "end")
            {
                if (command.StartsWith("green"))
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }                    
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
