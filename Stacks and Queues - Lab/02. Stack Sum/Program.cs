using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>(numbers);

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0].ToLower();

                if (action == "end")
                {
                    break;
                }

                if (action == "add")
                {
                    int firstNumber = int.Parse(command[1]);
                    int secondNumber = int.Parse(command[2]);

                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (action == "remove")
                {
                    int number = int.Parse(command[1]);

                    for (int i = 0; i < number; i++)
                    {
                        if (stack.Count < number)
                        {
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }

                    }                    
                }
            }

            int sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
