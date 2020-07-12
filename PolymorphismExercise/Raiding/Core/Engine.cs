using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Core.Contracts;
using Raiding.Factory;
using Raiding.IO.Contracts;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private ICollection<BaseHero> heroes;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine()
        {
            heroes = new List<BaseHero>();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int numberOfHeroes = int.Parse(reader.ReadLine());
            int counter = 0;
            while (numberOfHeroes != counter)
            {
                string name = Console.ReadLine();
                string typeOfHero = Console.ReadLine();

                try
                {
                    BaseHero hero = FactoryHeroes.CreateHero(typeOfHero, name);
                    heroes.Add(hero);
                    counter++;
                }
                catch (Exception ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            double bossPower = double.Parse(reader.ReadLine());

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            int sum = heroes.Sum(h => h.Power);

            writer.WriteLine(sum >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
