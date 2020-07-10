using System;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Model;

namespace Vehicles
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {

            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();


            int noOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < noOfCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    ProcessCommand(car, truck, cmdArgs);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private static void ProcessCommand(Vehicle car, Vehicle truck, string[] cmdArgs)
        {
            string cmdType = cmdArgs[0];
            string typeOfVehicle = cmdArgs[1];

            if (cmdType == "Drive")
            {
                if (cmdType == "Drive")
                {
                    double distanceToDrive = double.Parse(cmdArgs[2]);
                    if (typeOfVehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distanceToDrive));
                    }
                    else if (typeOfVehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distanceToDrive));
                    }
                }
            }
            else if (cmdType == "Refuel")
            {
                double amountToRefuel = double.Parse(cmdArgs[2]);
                if (typeOfVehicle == "Car")
                {
                    car.Refuel(amountToRefuel);
                }
                else if (typeOfVehicle == "Truck")
                {
                    truck.Refuel(amountToRefuel);
                }
            }
        }

        private Vehicle ProduceVehicle()
        {
            string[] vehicleArgs = Console.ReadLine().Split(' ');
            string type = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            //factory design pattern
            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption);
            return vehicle;
        }

    }
}