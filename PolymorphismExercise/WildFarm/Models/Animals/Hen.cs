using System;
using System.Collections.Generic;
using WildFarm.Exceptions;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private double weight;
        private const double henIncreaseFactor = 0.35;
        public Hen(string name, double weight, double wingsize) 
            : base(name, weight, wingsize)
        {
            
        }

        public override double WeightMultiplier => henIncreaseFactor;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>()
            {
                typeof(Vegetable)
                , typeof(Fruit)
                , typeof(Meat)
                , typeof(Seeds)
            };

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override double Weight
        {
            get => this.weight;
            protected set => this.weight = value;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {FoodEaten}]";
        }
    }
}
