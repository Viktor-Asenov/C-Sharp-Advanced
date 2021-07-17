using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threads = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int taskToBeKilled = int.Parse(Console.ReadLine());

            Stack<int> tasksStack = new Stack<int>(tasks);
            Queue<int> threadsQueue = new Queue<int>(threads);

            while (true)
            {
                int currentTaskValue = tasksStack.Peek();
                int currentThreadValue = threadsQueue.Peek();

                if (currentTaskValue == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {currentThreadValue} killed task {taskToBeKilled}");
                    break;
                }

                else if (currentThreadValue >= currentTaskValue)
                {
                    tasksStack.Pop();
                    threadsQueue.Dequeue();
                }

                else
                {
                    threadsQueue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(' ', threadsQueue).Trim());
        }
    }
}
