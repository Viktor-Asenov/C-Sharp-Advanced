using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person otherPerson)
        {
            if (this.Name.CompareTo(otherPerson.Name) != 0)
            {
                return this.Name.CompareTo(otherPerson.Name);
            }

            return this.Age.CompareTo(otherPerson.Age);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person otherPerson = (Person) obj;

            if (otherPerson == null)
            {
                return false;
            }

            return this.Name == otherPerson.Name && this.Age == otherPerson.Age;
        }
    }
}
