using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> carNumbers = new HashSet<string>();

            while (input != "END")
            {
                string[] commandParts = input.Split(", ");
                string command = commandParts[0];
                string carNumber = commandParts[1];

                if (command == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            if (carNumbers.Count > 0)
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }            
        }
    }
}
