using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        public Lake(List<T> stones)
        {
            this.Stones = stones;
        }

        public List<T> Stones { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Stones.Count; i++)
            {
                yield return this.Stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
