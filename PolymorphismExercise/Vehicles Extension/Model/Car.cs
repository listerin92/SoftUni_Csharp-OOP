namespace VehiclesExtension.Model
{
    public class Car : Vehicle
    {
        private const double SUMMER_AIRCOND_CONSUMPTION_INDEX = 0.9d;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + SUMMER_AIRCOND_CONSUMPTION_INDEX;
        }
    }
}