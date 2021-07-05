using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> findMin = GetMin;            

            Console.WriteLine(findMin(numbers));
        }

        public static int GetMin (List<int> numbers)
        {
            return numbers.Min();
        }
    }
}
