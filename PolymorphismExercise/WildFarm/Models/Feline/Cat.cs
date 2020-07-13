using System;
using System.Collections.Generic;
using WildFarm.Exceptions;

namespace WildFarm.Models.Feline
{
    public class Cat : Feline
    {
        private double weight;
        private const double catIncreaseFactor = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double Weight
        {
            get => this.weight;
            protected set
            {
                this.weight = value;
            }
        }

        public override double WeightMultiplier => catIncreaseFactor;

        public override ICollection<Type> PreferredFoods =>
        new List<Type>()
        {
            typeof(Vegetable)
            ,typeof(Meat)
        };

        public override string AskForFood()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
