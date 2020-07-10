using System;
using Vehicles.Exceptions;
using Vehicles.Model;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        /// <summary>
        /// Factory design pattern
        /// </summary>
        /// <param name="type"></param>
        /// <param name="fuelQuantity"></param>
        /// <param name="fuelConsumption"></param>
        /// <returns></returns>
        public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if(type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            if (vehicle == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidTypeExceptionMessage);
            }

            return vehicle;
        }
    }
}