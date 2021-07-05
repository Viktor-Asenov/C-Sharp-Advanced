using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int delimiter = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> reverseFunc = Reverse;

            numbers = reverseFunc(numbers);

            Predicate<int> evenPredicate = x => x % 2 == 0;
            Predicate<int> oddPredicate = x => x % 3 == 0;                      

            if (delimiter % 2 == 0)
            {
                numbers.RemoveAll(evenPredicate);
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                numbers.RemoveAll(oddPredicate);
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        public static List<int> Reverse (List<int> numbers)
        {
            numbers.Reverse();

            return numbers;
        }

    }
}
