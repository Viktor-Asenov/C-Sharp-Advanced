using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> liquids = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> ingredients = Console.ReadLine().Split().Select(int.Parse).ToList();

            int countBread = 0;
            int countCake = 0;
            int countPastry = 0;
            int countFruitPie = 0;

            for (int i = 0; i < liquids.Count; i++)
            { 
                for (int j = ingredients.Count - 1; j >= 0; j--)
                {
                    int currentLiquid = liquids[0];
                    int currentIngredient = ingredients[j];

                    if (currentLiquid + currentIngredient == 25)
                    {
                        liquids.Remove(liquids[0]);
                        ingredients.Remove(ingredients[j]);
                        countBread++;                        
                    }
                    else if (currentLiquid + currentIngredient == 50)
                    {
                        liquids.Remove(liquids[0]);
                        ingredients.Remove(ingredients[j]);
                        countCake++;
                    }
                    else if (currentLiquid + currentIngredient == 75)
                    {
                        liquids.Remove(liquids[0]);
                        ingredients.Remove(ingredients[j]);
                        countPastry++;
                    }
                    else if (currentLiquid + currentIngredient == 100)
                    {
                        liquids.Remove(liquids[0]);
                        ingredients.Remove(ingredients[j]);
                        countFruitPie++;
                    }
                    else
                    {
                        liquids.Remove(currentLiquid);
                        ingredients[j] += 3;
                        j++;
                    }
                    
                    if (liquids.Count == 0 || ingredients.Count == 0)
                    {
                        break;
                    }
                }

                if (liquids.Count == 0 || ingredients.Count == 0)
                {
                    break;
                }
            }

            if (liquids.Count == 0 && ingredients.Count == 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
                Console.WriteLine("Liquids left: none");
                Console.WriteLine("Ingredients left: none");                
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");

                if (liquids.Count == 0)
                {
                    ingredients.Sort();
                    Console.WriteLine("Liquids left: none");
                    Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
                }
                else if (ingredients.Count == 0)
                {
                    liquids.Sort();
                    Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
                    Console.WriteLine("Ingredients left: none");
                }                
            }

            Console.WriteLine($"Bread: {countBread}");
            Console.WriteLine($"Cake: {countCake}");
            Console.WriteLine($"Fruit Pie: {countFruitPie}");
            Console.WriteLine($"Pastry: {countPastry}");
        }
    }
}
