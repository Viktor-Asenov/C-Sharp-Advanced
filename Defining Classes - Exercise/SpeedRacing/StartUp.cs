using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
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
                double fuelAmount = double.Parse(currentCarInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(currentCarInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

                cars.Add(car);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] carData = command.Split();
                string carModel = carData[1];
                double distance = double.Parse(carData[2]);

                foreach (var car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.IsPossibleToDriveDistance(distance);
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
