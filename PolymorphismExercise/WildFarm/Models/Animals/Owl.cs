using System;
using System.Collections.Generic;
using WildFarm.Exceptions;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double owlIncreaseFactor = 0.25;

        public Owl(string name, double weight, double wingsize)
            : base(name, weight, wingsize)
        {

        }

        public override double WeightMultiplier => owlIncreaseFactor;

        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Meat) };

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {FoodEaten}]";
        }
    }
}
