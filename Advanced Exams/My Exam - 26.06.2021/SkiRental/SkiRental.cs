namespace SkiRental
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SkiRental
    {
        private IList<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Ski ski)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = null;
            foreach (var ski in this.data)
            {
                if (ski.Manufacturer == manufacturer && ski.Model == model)
                {
                    skiToRemove = ski;
                    this.data.Remove(skiToRemove);
                    return true;
                }
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            Ski newestSki = null;
            int newest = 0;
            foreach (var ski in this.data)
            {
                if (ski.Year > newest)
                {
                    newest = ski.Year;
                    newestSki = ski;
                }
            }

            return newestSki;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return this.data
                .Where(s => s.Manufacturer == manufacturer)
                .FirstOrDefault(s => s.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in this.data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
