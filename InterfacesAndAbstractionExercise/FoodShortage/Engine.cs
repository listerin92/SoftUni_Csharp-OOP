using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace FoodShortage
{
    public class Engine
    {
        public void Run()
        {
            string command;
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();
            int noOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < noOfLines; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs.Length == 4)
                {
                    string citizenName = cmdArgs[0];
                    int citizenAge = int.Parse(cmdArgs[1]);
                    string citizenId = cmdArgs[2];
                    DateTime citizenBirthday = DateTime.ParseExact(cmdArgs[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Citizen citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthday);
                    citizens.Add(citizen);

                }
                else if (cmdArgs.Length == 3)
                {
                    string rebelName = cmdArgs[0];
                    int rebelAge = int.Parse(cmdArgs[1]);
                    string rebelGroup = cmdArgs[2];
                    Rebel rebel = new Rebel(rebelName, rebelAge, rebelGroup);
                    rebels.Add(rebel);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                if (citizens.Any(x => x.Name == name))
                {
                    citizens.FirstOrDefault(x => x.Name == name).BuyFood();
                }
                else if (rebels.Any(x => x.Name == name))
                {
                    rebels.FirstOrDefault(x => x.Name == name).BuyFood();
                }
            }

            int finalFood = 0;
            foreach (var citizen in citizens)
            {
                finalFood += citizen.Food;
            }

            foreach (var rebel in rebels)
            {
                finalFood += rebel.Food;
            }

            Console.WriteLine(finalFood);
        }
    }
}
