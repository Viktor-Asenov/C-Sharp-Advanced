using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] currentCarInfo = Console.ReadLine().Split();
                string model = currentCarInfo[0];
                int engineSpeed = int.Parse(currentCarInfo[1]);
                int enginePower = int.Parse(currentCarInfo[2]);
                int cargoWeight = int.Parse(currentCarInfo[3]);
                string cargoType = currentCarInfo[4];

                Engine engine = new Engine(engineSpeed,enginePower);

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                List<Tire> currentCarTires = new List<Tire>();

                for (int j = 5; j <= currentCarInfo.Length - 1; j+=2)
                {
                    double tirePressure = double.Parse(currentCarInfo[j]);
                    int tireAge = int.Parse(currentCarInfo[j + 1]);

                    Tire tire = new Tire(tirePressure, tireAge);

                    currentCarTires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, currentCarTires.ToArray());

                cars.Add(car);
            }
            
            string command = Console.ReadLine();

            Func<Car, bool> filterFragile = c => c.Cargo.Type == "fragile" 
            && c.Tires.Min(t => t.Pressure) < 1;

            Func<Car, bool> filterFlamable = c => c.Cargo.Type == "flamable"
            && c.Engine.Power > 250;

            if (command == "fragile")
            {
                foreach (var car in cars.Where(filterFragile))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach (var car in cars.Where(filterFlamable))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
