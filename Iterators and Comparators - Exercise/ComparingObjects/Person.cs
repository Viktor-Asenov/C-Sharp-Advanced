using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }

        public int CompareTo(Person otherPerson)
        {
            if (this.Name.CompareTo(otherPerson.Name) != 0)
            {
                return this.Name.CompareTo(otherPerson.Name);
            }
            
            if (this.Age.CompareTo(otherPerson.Age) != 0)
            {
                return this.Age.CompareTo(otherPerson.Age);
            }

            return this.Town.CompareTo(otherPerson.Town);
        }
    }
}
