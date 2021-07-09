using System;
using System.Collections.Generic;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string personAdress = personInfo[2];

            Tuple<string, string> personFullData = new Tuple<string, string>(fullName, personAdress);

            string[] personBeerInfo = Console.ReadLine().Split();
            string personName = personBeerInfo[0];
            int beerLiters = int.Parse(personBeerInfo[1]);

            Tuple<string, int> personFullBeerInfo = new Tuple<string, int>(personName, beerLiters);

            string[] lastInfo = Console.ReadLine().Split();
            int firstValue = int.Parse(lastInfo[0]);
            double secondValue = double.Parse(lastInfo[1]);

            Tuple<int, double> values = new Tuple<int, double>(firstValue, secondValue);

            Console.WriteLine(personFullData);
            Console.WriteLine(personFullBeerInfo);
            Console.WriteLine(values);
        }
    }
}
