using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        private ICollection<ISoldier> solders;

        private Engine()
        {
            this.solders = new List<ISoldier>();
        }
        

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string solderType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];
                ISoldier soldier = null;
                if (solderType == "Private")
                {
                    soldier = AddPrivate(cmdArgs, id, firstName, lastName);
                }
                else if (solderType == "LieutenantGeneral")
                {
                    soldier = AddLieutenantGeneral(cmdArgs, id, firstName, lastName);
                }
                else if (solderType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        IEngineer engineer = Engineer(id, firstName, lastName, salary, corps, cmdArgs);

                        soldier = engineer;
                    }
                    catch (InvalidCorpsException e)
                    {
                        continue;

                    }
                }
                else if (solderType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        var commando = GetCommando(id, firstName, lastName, salary, corps, cmdArgs);

                        soldier = commando;
                    }
                    catch (InvalidCorpsException e)
                    {
                        continue;
                    }


                }
                else if (solderType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    this.solders.Add(soldier);
                }
            }

            foreach (var soldier in this.solders)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private static ICommando GetCommando(int id, string firstName, string lastName, decimal salary, string corps,
            string[] cmdArgs)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
            string[] missionArgs = cmdArgs.Skip(6).ToArray();
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    string missionCodeName = missionArgs[i];
                    string missionState = missionArgs[i + 1];
                    IMission mission = new Mission(missionCodeName, missionState);
                    commando.AddMission(mission);
                }
                catch (InvalidMissionStateException e)
                {
                    continue;
                }
            }

            return commando;
        }

        private static Engineer Engineer(int id, string firstName, string lastName, decimal salary, string corps,
            string[] cmdArgs)
        {
            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            string[] repairArgs = cmdArgs.Skip(6).ToArray();
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int horsWorked = int.Parse(repairArgs[i + 1]);
                IRepair repair = new Repair(partName, horsWorked);
                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ISoldier AddLieutenantGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            ILieutenantGeneral general =
                new LieutenantGeneral(id, firstName, lastName, salary);
            foreach (var pid in cmdArgs.Skip(5))
            {
                ISoldier privateToAdd = this.solders.First(s => s.Id == int.Parse(pid));
                general.AddPrivate(privateToAdd);
            }

            soldier = general;
            return soldier;
        }

        private static ISoldier AddPrivate(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return soldier;
        }
    }
}
