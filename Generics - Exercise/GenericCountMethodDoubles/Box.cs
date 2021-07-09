using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box<T> : IComparable<T>
        where T : IComparable<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }

        public int CompareTo(T otherValue)
        {
            return this.Value.CompareTo(otherValue);
        }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}
