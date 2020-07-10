using Vehicles.Model;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double PUNCH_IN_THE_RESERVOAR_PERCENTAGE = 0.95;
        private const double SUMMER_AIRCOND_CONSUMPTION_INDEX = 1.6;

        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + SUMMER_AIRCOND_CONSUMPTION_INDEX;
        }

        public override void Refuel(double amountToRefuel)
        {
            base.Refuel(amountToRefuel);/* * PUNCH_IN_THE_RESERVOAR_PERCENTAGE)*/;
        }
    }
}