using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class StartUp
    { 
        static void Main(string[] args)
        {
            CustomStack<int> customStack = new CustomStack<int>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries );
                
                if (tokens[0] == "Push")
                {
                    int[] numbers = tokens
                        .Skip(1)
                        .Select(i => i.Split(',').First())
                        .Select(int.Parse)                        
                        .ToArray();

                    customStack.Push(numbers);
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
                
            }

            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
