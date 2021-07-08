using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family ()
        {
            this.People = new List<Person>();
        }
        public List<Person> People { get; private set; }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
