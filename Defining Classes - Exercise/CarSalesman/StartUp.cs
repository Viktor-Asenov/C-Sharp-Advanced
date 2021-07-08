using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] currentEngineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = currentEngineInfo[0];
                int power = int.Parse(currentEngineInfo[1]);

                Engine engine = new Engine(model, power);

                if (currentEngineInfo.Length == 4)
                {
                    int displacement;

                    if (int.TryParse(currentEngineInfo[2], out displacement))
                    {
                        engine.Displacement = displacement;
                        engine.Efficiency = currentEngineInfo[3];
                    }
                    else
                    {
                        engine.Efficiency = currentEngineInfo[2];
                        engine.Displacement = int.Parse(currentEngineInfo[3]);
                    }
                }
                else if (currentEngineInfo.Length == 3)
                {
                    int displacement;

                    if (int.TryParse(currentEngineInfo[2], out displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = currentEngineInfo[2];
                    }
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] currentCarInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = currentCarInfo[0];
                string engineModel = currentCarInfo[1];

                Engine engine = engines.Where(e => e.Model == engineModel).First();
                Car car = new Car(carModel, engine);

                if (currentCarInfo.Length == 4)
                {
                    int weight;

                    if (int.TryParse(currentCarInfo[2], out weight))
                    {
                        car.Weight = weight;
                        car.Color = currentCarInfo[3];
                    }
                    else
                    {
                        car.Color = currentCarInfo[2];
                        car.Weight = int.Parse(currentCarInfo[3]);
                    }
                }
                else if (currentCarInfo.Length == 3)
                {
                    int weight;

                    if (int.TryParse(currentCarInfo[2], out weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = currentCarInfo[2];
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
