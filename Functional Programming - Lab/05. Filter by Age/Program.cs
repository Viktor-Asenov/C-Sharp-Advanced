using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_by_Age
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");                

                var person = new Person
                {
                    Name = input[0],
                    Age = int.Parse(input[1])
                };

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Func<Person, bool> filterPredicate;

            if (condition == "older")
            {
                filterPredicate = p => p.Age >= age;
            }
            else
            {
                filterPredicate = p => p.Age < age;
            }

            string format = Console.ReadLine();

            Func<Person, string> selectFunc;

            if (format == "name age")
            {
                selectFunc = p => $"{p.Name} - {p.Age}";
            }
            else
            {
                selectFunc = p => $"{p.Name}";
            }

            people
                .Where(filterPredicate)
                .Select(selectFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
