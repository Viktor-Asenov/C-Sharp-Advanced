using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            double comparisonElement = double.Parse(Console.ReadLine());

            Console.WriteLine(CountGreater(boxes, comparisonElement));
        }

        public static int CountGreater<T>(List<Box<T>> list, T element)
           where T : IComparable<T>
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
