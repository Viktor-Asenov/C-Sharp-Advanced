using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_For_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int orcWaves = int.Parse(Console.ReadLine());
            int[] aragornsPlates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> plates = new List<int>(aragornsPlates);
            Stack<int> orcs = new Stack<int>();

            bool isDestroyed = true;
            int wavesCounter = 0;
            for (int i = 0; i < orcWaves; i++)
            {
                int[] currentOrcWarriors = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                foreach (var orc in currentOrcWarriors)
                {
                    orcs.Push(orc);
                }

                wavesCounter++;
                if (wavesCounter % 3 == 0)
                {
                    int plateToAdd = int.Parse(Console.ReadLine());
                    plates.Add(plateToAdd);
                }

                while (plates.Count > 0 && orcs.Count > 0)
                { 
                    int currentPlate = plates[0];
                    int currentOrc = orcs.Peek();

                    if (currentOrc > currentPlate)
                    {
                        int currentOrcValue = orcs.Pop();
                        currentOrcValue -= currentPlate;
                        currentOrc = currentOrcValue;
                        orcs.Push(currentOrc);
                        if (currentOrc <= 0)
                        {
                            orcs.Pop();
                            continue;
                        }

                        plates.RemoveAt(0);
                    }
                    else if (currentPlate > currentOrc)
                    {
                        plates[0] -= currentOrc;
                        if (currentPlate <= 0)
                        {
                            plates.RemoveAt(0);
                            continue;
                        }

                        orcs.Pop();
                    }
                    else
                    {
                        plates.RemoveAt(0);
                        orcs.Pop();
                    }                    
                }
                
                if (orcs.Count == 0)
                {
                    isDestroyed = false;
                    continue;
                }
                else if (plates.Count == 0)
                {
                    isDestroyed = true;
                    break;
                }                
            }

            if (isDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
