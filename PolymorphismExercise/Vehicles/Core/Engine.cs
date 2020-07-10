using System;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.IO;
using Vehicles.IO.Contracts;
using Vehicles.Model;

namespace Vehicles
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


            int noOfCommands = int.Parse(reader.ReadLine());

            for (int i = 0; i < noOfCommands; i++)
            {
                string[] cmdArgs = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    ProcessCommand(car, truck, cmdArgs, writer);
                }
                catch (InvalidOperationException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
        }

        private static void ProcessCommand(Vehicle car, Vehicle truck, string[] cmdArgs, IWriter writer)
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
                        writer.WriteLine(car.Drive(distanceToDrive));
                    }
                    else if (typeOfVehicle == "Truck")
                    {
                        writer.WriteLine(truck.Drive(distanceToDrive));
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

        private Vehicle ProduceVehicle(IReader reader)
        {
            string[] vehicleArgs = reader.ReadLine().Split(' ');
            string type = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            //factory design pattern
            Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption);
            return vehicle;
        }

    }
}