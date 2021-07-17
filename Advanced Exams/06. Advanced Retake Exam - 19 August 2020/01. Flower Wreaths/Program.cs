using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int storedFlowers = 0;
            int countWreaths = 0;
            bool isAchieved = false;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currentLilie = lilies.Peek();
                int currentRose = roses.Peek();
                int currentSum = currentLilie + currentRose;

                if (currentSum == 15)
                {
                    lilies.Pop();
                    roses.Dequeue();
                    countWreaths++;
                }
                else if (currentSum > 15)
                {
                    int currentLilieValue = lilies.Pop();
                    currentLilieValue -= 2;
                    lilies.Push(currentLilieValue);
                }
                else
                {
                    storedFlowers += currentSum;
                    lilies.Pop();
                    roses.Dequeue();
                }

                if (countWreaths >= 5)
                {
                    isAchieved = true;
                }
            }
            
            if (storedFlowers >= 15)
            {
                int additionalWreaths = storedFlowers / 15;
                countWreaths += additionalWreaths;

                if (countWreaths >= 5)
                {
                    isAchieved = true;
                }
            }
            if (isAchieved == true)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countWreaths} wreaths!");
            }
            else
            {
                int neededWreaths = 5 - countWreaths;
                Console.WriteLine($"You didn't make it, you need {neededWreaths} wreaths more!");
            }
        }
    }
}
