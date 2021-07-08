using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currentPersonInfo = Console.ReadLine().Split();
                string name = currentPersonInfo[0];
                int age = int.Parse(currentPersonInfo[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            people = people                
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
