using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IResident> citizens = new List<IResident>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ');
                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                IResident citizen = new Citizen(name, country, age);
                citizens.Add(citizen);
             
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine(citizen.Name);
                Console.WriteLine(citizen.GetName());
            }

        }
    }
}
