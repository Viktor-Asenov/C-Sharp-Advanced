using System;
using System.Collections.Generic;
using System.Linq;

namespace Other
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] ingredientsData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsData);
            Stack<int> ingredients = new Stack<int>(ingredientsData);

            int countBread = 0;
            int countCake = 0;
            int countPastry = 0;
            int countFruitPie = 0;

            while (true)
            {
                if (liquids.Count == 0 || ingredients.Count == 0)
                {
                    break;
                }

                int currentLiquid = liquids.Peek();
                int currentIngredient = ingredients.Peek();

                if (currentLiquid + currentIngredient == 25)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    countBread++;
                }
                else if (currentLiquid + currentIngredient == 50)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    countCake++;
                }
                else if (currentLiquid + currentIngredient == 75)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    countPastry++;
                }
                else if (currentLiquid + currentIngredient == 100)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                    countFruitPie++;
                }
                else
                {
                    liquids.Dequeue();
                    var lastElement = ingredients.Pop();
                    lastElement += 3;
                    ingredients.Push(lastElement);
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

                if (liquids.Count == 0 && ingredients.Count > 0)
                {
                    ingredients.ToList().Sort();
                    Console.WriteLine("Liquids left: none");
                    Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
                }
                else if (ingredients.Count == 0 && liquids.Count > 0)
                {
                    liquids.ToList().Sort();
                    Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
                    Console.WriteLine("Ingredients left: none");
                }
                else if (liquids.Count > 0 && ingredients.Count > 0)
                {
                    liquids.ToList().Sort();
                    ingredients.ToList().Sort();
                    Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
                    Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
                }
            }

            Console.WriteLine($"Bread: {countBread}");
            Console.WriteLine($"Cake: {countCake}");
            Console.WriteLine($"Fruit Pie: {countFruitPie}");
            Console.WriteLine($"Pastry: {countPastry}");
        }
    }
}
