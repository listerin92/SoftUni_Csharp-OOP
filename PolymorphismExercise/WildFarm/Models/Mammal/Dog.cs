
using System;
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
        public override void Feed(Food.Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.FoodEaten = food.Quantity;
                this.Weight += food.Quantity * dogIncreaseFactor;
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
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}