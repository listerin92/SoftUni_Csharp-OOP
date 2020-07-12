using System;
using Vehicles.Exceptions;

namespace VehiclesExtension.Model
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
        }

        public override string Drive(double distanceToDrive)
        {
            double consumedFuel = distanceToDrive * (this.FuelConsumption + 1.4);
            if (this.FuelQuantity < consumedFuel)
            {
                string msg = String.Format(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name);
                throw new InvalidOperationException(msg);

            }
            this.FuelQuantity -= consumedFuel;
            return $"{this.GetType().Name} travelled {distanceToDrive} km";
        }

    }
}