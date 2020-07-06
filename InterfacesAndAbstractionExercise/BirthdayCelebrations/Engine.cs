using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public class Engine
    {
        public void Run()
        {
            string command;
            List<string> birthdays = new List<string>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0] == "Citizen")
                {
                    string citizenName = cmdArgs[1];
                    int citizenAge = int.Parse(cmdArgs[2]);
                    string citizenId = cmdArgs[3];
                    string citizenBirthday = cmdArgs[4];
                    Citizen citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthday);
                    birthdays.Add(citizenBirthday);
                }
                else if (cmdArgs[0] == "Robot")
                {
                    string robotModel = cmdArgs[1];
                    string robotId = cmdArgs[2];
                    Robot robot = new Robot(robotModel, robotId);
                    birthdays.Add(robotId);
                }
                else if (cmdArgs[0] == "Pet")
                {
                    string petName = cmdArgs[1];
                    string petBirthday = cmdArgs[2];
                    Pet pet = new Pet(petName, petBirthday);
                    birthdays.Add(petBirthday);
                }
            }

            string specificYear = Console.ReadLine();
            if (birthdays.Any(x => x.EndsWith(specificYear ?? string.Empty)))
            {
                foreach (var id in birthdays.Where(x => x.EndsWith(specificYear ?? string.Empty)))
                {
                    Console.WriteLine(id);
                }
            }
            else
            {
                Console.WriteLine("");
            }
            
        }
    }
}
