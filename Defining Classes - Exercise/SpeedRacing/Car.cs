using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car (string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void IsPossibleToDriveDistance(double distance)
        {
            double wholeForDriving = distance * FuelConsumptionPerKilometer;

            if (wholeForDriving <=  FuelAmount)
            {
                this.FuelAmount -= wholeForDriving;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }            
        }
    }
}
