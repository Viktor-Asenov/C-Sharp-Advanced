using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string personNeighbourhood = personInfo[2];
            string city = personInfo[3];

            Threeuple<string, string, string> personFullData = 
                new Threeuple<string, string, string>(fullName, personNeighbourhood, city);

            string[] personBeerInfo = Console.ReadLine().Split();
            string personName = personBeerInfo[0];
            int beerLiters = int.Parse(personBeerInfo[1]);
            bool isDrunk = personBeerInfo[2] == "drunk" ? true : false;

            Threeuple<string, int, bool> personFullBeerInfo =
                new Threeuple<string, int, bool>(personName, beerLiters, isDrunk);

            string[] personBankInfo = Console.ReadLine().Split();
            string name = personBankInfo[0];
            double accountBalance = double.Parse(personBankInfo[1]);
            string bankName = personBankInfo[2];

            Threeuple<string, double, string> personFullBankInfo =
                new Threeuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine(personFullData);
            Console.WriteLine(personFullBeerInfo);
            Console.WriteLine(personFullBankInfo);
        }
    }
}
