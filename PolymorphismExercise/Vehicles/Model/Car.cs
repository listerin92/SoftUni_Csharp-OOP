using Vehicles.Model;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private double fuelConsumptionLpK;
        private const double SUMMER_AIRCOND_CONSUMPTION_INDEX = 0.9d;
        public Car(double fuelQuantity, double fuelConsumptionLpK) : base(fuelQuantity, fuelConsumptionLpK)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + SUMMER_AIRCOND_CONSUMPTION_INDEX;
        }
    }
}