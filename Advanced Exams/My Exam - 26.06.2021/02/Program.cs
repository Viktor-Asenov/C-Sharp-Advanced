using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> freshnessLevels = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> dishes = new Dictionary<string, int>();
            int dippingSause = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;
            int countDishes = 0;

            while (ingredients.Count > 0 && freshnessLevels.Count > 0)
            {
                int currentIngredient = ingredients.Peek();
                int currentFreshnessLevel = freshnessLevels.Peek();
                int currentSum = currentIngredient * currentFreshnessLevel;

                if (currentSum == 150)
                {
                    if (!dishes.ContainsKey("Dipping sauce"))
                    {
                        dishes["Dipping sauce"] = dippingSause;
                    }

                    dishes["Dipping sauce"]++;
                    dippingSause++;
                    countDishes++;
                    ingredients.Dequeue();
                    freshnessLevels.Pop();
                }
                else if (currentSum == 250)
                {
                    if (!dishes.ContainsKey("Green salad"))
                    {
                        dishes["Green salad"] = greenSalad;
                    }

                    dishes["Green salad"]++;
                    greenSalad++;
                    countDishes++;
                    ingredients.Dequeue();
                    freshnessLevels.Pop();
                }
                else if (currentSum == 300)
                {
                    if (!dishes.ContainsKey("Chocolate cake"))
                    {
                        dishes["Chocolate cake"] = chocolateCake;
                    }

                    dishes["Chocolate cake"]++;
                    chocolateCake++;
                    countDishes++;
                    ingredients.Dequeue();
                    freshnessLevels.Pop();
                }
                else if (currentSum == 400)
                {
                    if (!dishes.ContainsKey("Lobster"))
                    {
                        dishes["Lobster"] = lobster;
                    }

                    dishes["Lobster"]++;
                    lobster++;
                    countDishes++;
                    ingredients.Dequeue();
                    freshnessLevels.Pop();
                }
                else
                {                    
                    if (currentIngredient == 0)
                    {
                        ingredients.Dequeue();
                    }
                    else
                    {
                        freshnessLevels.Pop();
                        int currentIngredientValue = ingredients.Dequeue();
                        currentIngredientValue += 5;
                        ingredients.Enqueue(currentIngredientValue);
                    }
                }
            }

            if (countDishes >= 4 && dippingSause > 0 && greenSalad > 0
                && chocolateCake > 0 && lobster > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                int sumIngredients = ingredients.Sum();
                Console.WriteLine($"Ingredients left: {sumIngredients}");
            }

            var sorted = dishes.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var dish in sorted)
            {
                Console.WriteLine($"# {dish.Key} --> {dish.Value}");
            }
        }
    }
}
