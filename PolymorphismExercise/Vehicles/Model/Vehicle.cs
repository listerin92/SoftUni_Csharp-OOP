using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Exceptions;

namespace Vehicles.Model
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        public Vehicle(double fuelQuantity, double litersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = litersPerKm;
        }

        public double FuelQuantity { get; protected set; }
        public virtual double FuelConsumption { get; protected set; }

        public string Drive(double distanceToDrive)
        {
            double consumedFuel = distanceToDrive * this.FuelConsumption;
            if (this.FuelQuantity < consumedFuel)
            {
                string msg = String.Format(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name);
                throw new InvalidOperationException(msg);

            }
            this.FuelQuantity -= consumedFuel;
            return $"{this.GetType().Name} travelled {distanceToDrive} km";
        }

        public virtual void Refuel(double amountToRefuel)
        {
            if (amountToRefuel > 0)
            {
                this.FuelQuantity += amountToRefuel;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Math.Round(this.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}";
        }
    }
}