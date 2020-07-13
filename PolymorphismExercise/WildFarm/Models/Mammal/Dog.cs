
using System;
using System.Collections.Generic;
using WildFarm.Exceptions;

namespace WildFarm.Models.Mammal
{
    public class Dog : Mammal
    {
        private const double dogIncreaseFactor = 0.4;

        public Dog(string name, double weight, string livingregion)
            : base(name, weight)
        {
            this.LivingRegion = livingregion;
        }

        public override double Weight { get; protected set; }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override double WeightMultiplier => dogIncreaseFactor;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>()
            {
                typeof(Meat)
            };

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}