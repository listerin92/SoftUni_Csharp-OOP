using System;
using WildFarm.Exceptions;
using WildFarm.Models;
using WildFarm.Models.Animals;
using WildFarm.Models.Feline;
using WildFarm.Models.Food;
using WildFarm.Models.Mammal;

namespace WildFarm.Factory
{
    public class AnimalFactory
    {
        public Animal ProduceAnimal(string command)
        {
            string[] animalArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);
            string livingRegion;
            string breed;
            double wingsize = 0;
            Animal animal = null;
            if (type == "Owl")
            {
                wingsize = double.Parse(animalArgs[3]);
                animal = new Owl(name, weight, wingsize);
            }
            else if (type == "Hen")
            {
                wingsize = double.Parse(animalArgs[3]);
                animal = new Hen(name, weight, wingsize);
            }
            else if (type == "Mouse")
            {
                livingRegion = animalArgs[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                livingRegion = animalArgs[3];
                breed = animalArgs[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                livingRegion = animalArgs[3];
                breed = animalArgs[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == "Dog")
            {
                livingRegion = animalArgs[3];
                animal = new Dog(name, weight, livingRegion);
            }
            if (animal == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidTypeExceptionMessage);
            }

            return animal;
        }

        public Food ProduceFood(string command)
        {
            string[] foodArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string vegitableName = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);
            Food food = null;
            if (vegitableName == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (vegitableName == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (vegitableName == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (vegitableName == "Seeds")
            {
                food = new Seeds(quantity);
            }

            if (vegitableName == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidTypeExceptionMessage);
            }
            return food;
        }
    }
}
