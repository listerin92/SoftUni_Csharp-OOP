using System;
using System.Collections.Generic;
using WildFarm.Exceptions;

namespace WildFarm.Models.Mammal
{
    public class Mouse : Mammal
    {
        private const double mouseIncreaseFactor = 0.1;

        public Mouse(string name, double weight, string livingregion)
            : base(name, weight)
        {
            this.LivingRegion = livingregion;
        }

        public override double Weight { get; protected set; }

        public override double WeightMultiplier => mouseIncreaseFactor;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>()
            {
                typeof(Vegetable)
                ,typeof(Fruit)
            };

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
