using System;
using Vehicles.Exceptions;
using Vehicles.Model;
using VehiclesExtension.Model;

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
        /// <param name="tankCapacity"></param>
        /// <returns></returns>
        public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if(type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            if (vehicle == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidTypeExceptionMessage);
            }

            return vehicle;
        }
    }
}