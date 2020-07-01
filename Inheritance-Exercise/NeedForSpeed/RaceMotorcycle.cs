namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public double DefaultFuelConsumption { get; set; } = 8;
        public override void Drive(double kilometers)
        {
            this.Fuel -= (this.DefaultFuelConsumption / 100) * kilometers;
        }
    }
}