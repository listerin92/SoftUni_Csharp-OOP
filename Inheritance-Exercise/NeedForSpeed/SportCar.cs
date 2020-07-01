namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public new double DefaultFuelConsumption { get; set; } = 10;
        public override void Drive(double kilometers)
        {
            this.Fuel -= (this.DefaultFuelConsumption / 100) * kilometers;
        }
    }
}