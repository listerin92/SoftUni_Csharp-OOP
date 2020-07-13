using System;
using System.Collections;
using System.Collections.Generic;
using VehiclesExtension.Core.Contracts;
using VehiclesExtension.IO.Contracts;
using WildFarm.Factory;
using WildFarm.Models.Animals;
using WildFarm.Models.Food;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly AnimalFactory animalFactory;
        private readonly IReader reader;
        private readonly IWriter writer;
        private IList<Animal> animals;
        public Engine()
        {
            animals = new List<Animal>();
            animalFactory = new AnimalFactory();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string cmdLineOne;
            while ((cmdLineOne = reader.ReadLine()) != "End")
            {

                Animal animal = this.animalFactory.ProduceAnimal(cmdLineOne);
                string cmdLineTwo = reader.ReadLine();
                Food food = this.animalFactory.ProduceFood(cmdLineTwo);
                writer.WriteLine(animal.AskForFood());

                try
                {
                    animal.Feed(food);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
                animals.Add(animal);

            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }

        }

    }
}