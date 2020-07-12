using System;
using Vehicles.Contracts;
using Vehicles.Exceptions;

namespace VehiclesExtension.Model
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private double tankCapacity;
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = litersPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                this.fuelQuantity = value;

                if (value < 0)
                {
                    this.fuelQuantity = 0;
                    string msg = ExceptionMessages.NegativeFuelException;
                    throw new InvalidOperationException(msg);
                }
            }
        }

        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            protected set
            {
                this.fuelConsumption = value;

                if (value <= 0)
                {
                    this.fuelConsumption = 0;
                    string msg = ExceptionMessages.NegativeFuelException;
                    throw new InvalidOperationException(msg);
                }
            }
        }

        public double TankCapacity
        {
            get => tankCapacity;
            protected set
            {
                if (this.FuelQuantity > value)
                {
                    this.FuelQuantity = 0;
                }
                tankCapacity = value;
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

            if (amountToRefuel > this.TankCapacity - this.FuelQuantity)
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