using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] currentPersonData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = currentPersonData[0];
                int age = int.Parse(currentPersonData[1]);
                string town = currentPersonData[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person personToCompareWith = people[index];

            int equal = 0;
            int notEqual = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompareWith) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (equal > 1)
            {
                Console.WriteLine($"{equal} {notEqual} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
