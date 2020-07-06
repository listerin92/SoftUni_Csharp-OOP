using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Engine
    {
        public void Run()
        {
            string command = string.Empty;
            List<string> ids = new List<string>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ');
                if (cmdArgs.Length == 3)
                {
                    string citizenName = cmdArgs[0];
                    int citizenAge = int.Parse(cmdArgs[1]);
                    string citizenId = cmdArgs[2];
                    Citizen citizen = new Citizen(citizenName, citizenAge, citizenId);
                    ids.Add(citizenId);
                }
                else if (cmdArgs.Length == 2)
                {
                    string robotModel = cmdArgs[0];
                    string robotId = cmdArgs[1];
                    Robot robot = new Robot(robotModel, robotId);
                    ids.Add(robotId);
                }
            }

            string detainedId = Console.ReadLine();
            foreach (var id in ids.Where(x => x.EndsWith(detainedId)))
            {
                Console.WriteLine(id);
            }
        }
    }
}