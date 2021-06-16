using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char current = expression[i];

                if (current == '(')
                {
                    stack.Push(i);
                }
                else if (current == ')')
                {
                    int start = stack.First();
                    int lenght = i - start;
                    var substring = expression.Substring(start, lenght + 1);

                    Console.WriteLine(substring);
                    stack.Pop();
                }
            }
        }
    }
}
