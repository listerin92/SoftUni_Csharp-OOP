using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(200, 70);
            sportCar.Drive(100);
            Console.WriteLine(sportCar.Fuel);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(200, 70);
            raceMotorcycle.Drive(100);
            Console.WriteLine(raceMotorcycle.Fuel);
            Car car = new Car(200, 70);
            car.Drive(100);
            Console.WriteLine(car.Fuel);

        }
    }
}