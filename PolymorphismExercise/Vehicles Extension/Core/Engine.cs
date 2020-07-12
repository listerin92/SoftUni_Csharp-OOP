using System;
using VehiclesExtension.Core.Contracts;
using VehiclesExtension.Factories;
using VehiclesExtension.IO.Contracts;
using VehiclesExtension.Model;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {

            Vehicle car = ProduceVehicle(reader);
            Vehicle truck = ProduceVehicle(reader);
            Vehicle bus = ProduceVehicle(reader);

            int noOfCommands = int.Parse(reader.ReadLine());

            for (int i = 0; i < noOfCommands; i++)
            {
                string[] cmdArgs = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    ProcessCommand(car, truck, bus, cmdArgs, writer);
                }
                catch (InvalidOperationException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
            writer.WriteLine(bus.ToString());
        }

        private static void ProcessCommand(Vehicle car, Vehicle truck, Vehicle bus, string[] cmdArgs, IWriter writer)
        {
            string cmdType = cmdArgs[0];
            string typeOfVehicle = cmdArgs[1];


            if (cmdType == "Drive")
            {
                double distanceToDrive = double.Parse(cmdArgs[2]);
                if (typeOfVehicle == "Car")
                {
                    writer.WriteLine(car.Drive(distanceToDrive));
                }
                else if (typeOfVehicle == "Truck")
                {
                    writer.WriteLine(truck.Drive(distanceToDrive));
                }
                else if (typeOfVehicle == "Bus")
                {
                    writer.WriteLine(bus.Drive(distanceToDrive));
                }
            }

            else if (cmdType == "DriveEmpty")
            {
                double distanceToDrive = double.Parse(cmdArgs[2]);
                writer.WriteLine(bus.DriveEmpty(distanceToDrive));
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
                else if (typeOfVehicle == "Bus")
                {
                    bus.Refuel(amountToRefuel);
                }
            }
        }

        private Vehicle ProduceVehicle(IReader read)
        {
            string[] vehicleArgs = read.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);
            //factory design pattern
            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);
            return vehicle;
        }
    }
}