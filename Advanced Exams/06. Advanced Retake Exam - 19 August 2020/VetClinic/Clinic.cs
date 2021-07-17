namespace VetClinic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Clinic
    {
        private IList<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet petToRemove = null;
            foreach (var pet in this.data)
            {
                if (pet.Name == name)
                {
                    petToRemove = pet;
                    this.data.Remove(petToRemove);
                    return true;
                }
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = null;
            foreach (var currentPet in this.data)
            {
                if (currentPet.Name == name && currentPet.Owner == owner)
                {
                    pet = currentPet;
                }
            }

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet oldest = null;
            int oldestPet = int.MinValue;
            foreach (var pet in this.data)
            {
                if (pet.Age > oldestPet)
                {
                    oldestPet = pet.Age;
                    oldest = pet;
                }
            }

            return oldest;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
