﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car (string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }
        public string Make { get; private set; }
        
        public string Model { get; private set; }
        
        public int HorsePower { get; private set; }
        
        public string RegistrationNumber { get; private set; }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"HorsePower: {this.HorsePower}");
            result.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");

            return result.ToString();
        }
    }
}
