using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] memberInfo = Console.ReadLine().Split();
                string name = memberInfo[0];
                int age = int.Parse(memberInfo[1]);

                Person currentPerson = new Person(name, age);

                family.AddMember(currentPerson);
            }

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");         
            
        }
    }
}
