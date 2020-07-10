using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Exceptions;

namespace Vehicles.Model
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private double fuelQuantity;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = litersPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity
        {
            get => tankCapacity;
            protected set
            {
                tankCapacity = value;

                if (this.FuelQuantity > this.TankCapacity)
                {
                    this.FuelQuantity = 0;
                }
            }
        }

        public virtual string Drive(double distanceToDrive)
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
        public string DriveEmpty(double distanceToDrive)
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
            if (amountToRefuel <= 0)
            {
                string msg = String.Format(ExceptionMessages.NegativeFuelException);
                throw new InvalidOperationException(msg);
            }

            if (amountToRefuel + this.FuelQuantity > this.TankCapacity)
            {
                string msg = String.Format(ExceptionMessages.TooMuchFuelException, amountToRefuel);
                throw new InvalidOperationException(msg);
            }
            this.FuelQuantity += amountToRefuel;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Math.Round(this.FuelQuantity, 2, MidpointRounding.AwayFromZero):f2}";
        }
    }
}