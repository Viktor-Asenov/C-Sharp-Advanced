using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            List<int> claimedItems = new List<int>();
            
            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int currentItemFirstLootBox = firstLootBox.Peek();
                int currentItemSecondLootBox = secondLootBox.Peek();
                int currentSum = currentItemFirstLootBox + currentItemSecondLootBox;

                if (currentSum % 2 == 0)
                {
                    claimedItems.Add(currentSum);
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    currentItemSecondLootBox = secondLootBox.Pop();
                    firstLootBox.Enqueue(currentItemSecondLootBox);
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
