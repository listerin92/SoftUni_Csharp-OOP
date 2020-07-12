using System;
using WildFarm.Exceptions;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double owlIncreaseFactor = 0.25;

        public Owl(string name, double weight, double wingsize)
            : base(name, weight, wingsize)
        {

        }
        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
        public override void Feed(Food.Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.FoodEaten = food.Quantity;
                this.Weight += food.Quantity * owlIncreaseFactor;
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
