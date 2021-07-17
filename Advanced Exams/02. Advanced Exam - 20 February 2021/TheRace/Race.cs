using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private IList<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Racer racer)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if (this.data.Any(r => r.Name == name))
            {
                Racer racerToRemove = this.data.First(r => r.Name == name);
                this.data.Remove(racerToRemove);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            Racer oldestRacer = null;
            int oldest = 0;
            foreach (var racer in this.data)
            {
                if (racer.Age > oldest)
                {
                    oldest = racer.Age;
                    oldestRacer = racer;
                }
            }

            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            return this.data.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            Racer fastestRacer = null;
            int fastestSpeed = 0;
            foreach (var racer in this.data)
            {
                if (racer.Car.Speed > fastestSpeed)
                {
                    fastestSpeed = racer.Car.Speed;
                    fastestRacer = racer;
                }                
            }

            return fastestRacer;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in this.data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
