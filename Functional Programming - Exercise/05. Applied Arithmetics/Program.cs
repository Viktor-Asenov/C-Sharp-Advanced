using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    Func<List<int>, List<int>> addFunc = Add;                    

                    numbers = addFunc(numbers);
                }
                else if (command == "multiply")
                {
                    Func<List<int>, List<int>> multiplyFunc = Multiply;

                    numbers = multiplyFunc(numbers);
                }
                else if (command == "subtract")
                {
                    Func<List<int>, List<int>> subtractFunc = Subtract;

                    numbers = subtractFunc(numbers);
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                command = Console.ReadLine();
            }
        }

        public static List<int> Add (List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] += 1;
            }
            
            return numbers;
        }

        public static List<int> Multiply (List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= 2;
            }

            return numbers;
        }

        public static List<int> Subtract (List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] -= 1;
            }

            return numbers;
        }
    }
}
