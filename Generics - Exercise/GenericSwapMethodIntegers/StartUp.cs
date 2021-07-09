using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap(boxes, firstIndex, secondIndex);

            Console.WriteLine(string.Join(Environment.NewLine, boxes));
        }

        public static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            var firstElement = list[firstIndex];
            var secondElement = list[secondIndex];

            list[firstIndex] = secondElement;
            list[secondIndex] = firstElement;
        }
    }    
}

