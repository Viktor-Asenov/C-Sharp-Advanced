using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count 
        { 
            get { return this.data.Count; }
        }

        public void Add(Employee employee)
        {
            if (this.data.Count < this.Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            bool isRemoved = false;

            if (this.data.Any(e => e.Name == name))
            {
                isRemoved = true;
            }

            return isRemoved;
        }

        public Employee GetOldestEmployee()
        {
            int oldestAge = 0;
            var oldestEmployee = new object();

            foreach (var employee in this.data)
            {
                if (employee.Age > oldestAge)
                {
                    oldestAge = employee.Age;
                    oldestEmployee = employee;
                }
            }

            return (Employee) oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            var employee = this.data.Find(e => e.Name == name);

            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString();
        }
    }
}
