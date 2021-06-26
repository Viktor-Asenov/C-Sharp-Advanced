using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.__Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string currentQuery = Console.ReadLine();

                if (currentQuery.StartsWith("1"))
                {
                    var newQuery = currentQuery.Split();
                    int numberToPush = int.Parse(newQuery[1]);

                    stack.Push(numberToPush);
                }
                else if (currentQuery.StartsWith("2"))
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentQuery.StartsWith("3"))
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }                    
                }
                else if (currentQuery.StartsWith("4"))
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            stack.ToString();
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
