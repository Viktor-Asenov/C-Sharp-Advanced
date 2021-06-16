using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            var parts = expression.Split();

            var stack = new Stack<string>(parts.Reverse());
            var result = 0;

            while (stack.Count > 0)
            {
                var element = stack.Pop();

                if (element == "+")
                {
                    var number = int.Parse(stack.Pop());

                    result += number;
                }
                else if (element == "-")
                {
                    var number = int.Parse(stack.Pop());
                    result -= number;
                }
                else
                {
                    result = int.Parse(element);
                }
            }

            Console.WriteLine(result);
        }
    }
}
