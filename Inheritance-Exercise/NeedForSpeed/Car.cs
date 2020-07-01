namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public new double DefaultFuelConsumption { get; set; } = 3;
        public override void Drive(double kilometers)
        {
            this.Fuel -= (this.DefaultFuelConsumption / 100) * kilometers;
        }
    }
}