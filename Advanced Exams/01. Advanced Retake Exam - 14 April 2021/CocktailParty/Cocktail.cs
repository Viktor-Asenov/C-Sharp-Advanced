namespace CocktailParty
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cocktail
    {
        private IList<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.ingredients = new List<Ingredient>();
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;            
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int MaxAlcoholLevel { get; private set; }

        public int CurrentAlcoholLevel => this.ingredients.Sum(i => i.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (this.ingredients.Count < this.Capacity
                && this.ingredients.Sum(i => i.Alcohol) + ingredient.Alcohol <= this.MaxAlcoholLevel
                && !(this.ingredients.Any(i => i.Name == ingredient.Name)))
            {
                this.ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            foreach (var ingredient in this.ingredients)
            {
                if (ingredient.Name == name)
                {
                    this.ingredients.Remove(ingredient);
                    return true;
                }
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return this.ingredients.FirstOrDefault(i => i.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            int maxAlcohol = int.MinValue;
            Ingredient mostAlcoholic = null;

            foreach (var ingredient in this.ingredients)
            {
                if (ingredient.Alcohol > maxAlcohol)
                {
                    maxAlcohol = ingredient.Alcohol;
                    mostAlcoholic = ingredient;
                }
            }

            return mostAlcoholic;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var ingredient in this.ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
