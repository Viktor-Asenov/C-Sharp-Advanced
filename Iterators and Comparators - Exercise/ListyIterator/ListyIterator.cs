using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private int index;
        private List<T> collection;

        public ListyIterator(params T[] collection)             
        {
            this.collection = new List<T>(collection);
        }
        
        public bool Move()
        {
            if (collection.Count - 1 > index )
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return index + 1 < collection.Count;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(collection[index]);
        }
    }
}
