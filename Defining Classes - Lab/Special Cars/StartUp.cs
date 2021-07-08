using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }

                string[] tiresData = command.Split();
                List<Tire> tireList = new List<Tire>();

                for (int i = 0; i < tiresData.Length; i+=2)
                {
                    int year = int.Parse(tiresData[i]);
                    double pressure = double.Parse(tiresData[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tireList.Add(tire);
                }

                tires.Add(tireList.ToArray());
            }

            List<Engine> engines = new List<Engine>();

            while (true) 
            {
                string command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }

                string[] engineData = command.Split();
                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special")
                {
                    break;
                }

                string[] carInfo = command.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption,
                    engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }

            Func<Car, bool> filter = c => c.Year >= 2017 && c.Engine.HorsePower > 330
            && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10;

            List<Car> specialCars = new List<Car>();

            foreach (Car car in cars.Where(filter))
            {
                car.Drive(20);
                specialCars.Add(car);
            }

            Console.WriteLine(string.Join("", specialCars));
        }
    }
}
