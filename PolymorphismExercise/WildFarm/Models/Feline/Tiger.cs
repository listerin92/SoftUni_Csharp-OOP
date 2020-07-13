using System;
using System.Collections.Generic;
using WildFarm.Exceptions;
using WildFarm.Models.Feline;
using WildFarm.Models.Food;

namespace WildFarm.Models.Feline

{
    public class Tiger : Feline
    {
        private const double tigerIncreaseFactor = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double Weight { get; protected set; }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override double WeightMultiplier => tigerIncreaseFactor;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>()
            {
                typeof(Meat)
            };
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
