using System;

namespace SoftUniParking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstCar = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var secondCar = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(firstCar.ToString());
            //Make: Skoda
            //Model: Fabia
            //HorsePower: 65
            //RegistrationNumber: CC1856BG

            var parking = new Parking(5);
            Console.WriteLine(parking.AddCar(firstCar));
            //Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.AddCar(firstCar));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(secondCar));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            //Make: Audi
            //Model: A3
            //HorsePower: 110
            //RegistrationNumber: EB8787MN

            Console.WriteLine(parking.RemoveCar("EB8787MN"));
            //Successfullyremoved EB8787MN

            Console.WriteLine(parking.Count); //1

        }
    }
}
