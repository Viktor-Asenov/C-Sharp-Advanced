using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> values;

        public Box()
        {
            this.values = new List<T>();
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            this.values.Add(element);
            this.Count++;
        }

        public T Remove()
        {
            var last = this.values.Last();
            this.values.Remove(last);
            this.Count--;
            return last;
        }
    }
}
