using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<decimal>();
                }

                students[name].Add(grade);
            }

            foreach (var kvp in students)
            {
                Console.Write($"{kvp.Key} -> ");

                foreach (var mark in kvp.Value)
                {
                    Console.Write($"{mark:f2} ");
                }

                Console.Write($"(avg: {kvp.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
