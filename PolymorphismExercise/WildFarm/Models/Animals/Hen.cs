using System;
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
        public override string AskForFood()
        {
            return "Cluck";
        }

        public override double Weight
        {
            get => this.weight;
            protected set => this.weight = value;
        }

        public override void Feed(Food.Food food)
        {
            if (food.GetType().Name == "Vegetable" ||
                food.GetType().Name == "Fruit" ||
                food.GetType().Name == "Meat" ||
                food.GetType().Name == "Seeds")
            {
                this.FoodEaten = food.Quantity;
                this.Weight += food.Quantity * henIncreaseFactor;
            }
            else
            {
                string msg = string.Format(ExceptionMessages.InvalidFoodExceptionMessage, this.GetType().Name,
                    food.GetType().Name);
                throw new InvalidOperationException(msg); 
            }

        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {FoodEaten}]";
        }
    }
}
