using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var playlist = Console.ReadLine().Split(", ");
            var queue = new Queue<string>(playlist);

            while (queue.Any())
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {                    
                    queue.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string songName = command.Substring(4);

                    if (queue.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(songName);
                    }
                }
                else if (command == "Show")
                {                    
                    Console.WriteLine(string.Join(", ", queue));
                }                
            }

            Console.WriteLine("No more songs!");
        }
    }
}
