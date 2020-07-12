using System;
using WildFarm.Exceptions;

namespace WildFarm.Models.Mammal
{
    public class Mouse : Mammal
    {
        private const double mouseIncreaseFactor = 0.15;

        public Mouse(string name, double weight, string livingregion)
            : base(name, weight)
        {
            this.LivingRegion = livingregion;
        }

        public override double Weight { get; protected set; }

        public override string AskForFood()
        {
            return "Squeak";
        }
        public override void Feed(Food.Food food)
        {
            if (food.GetType().Name == "Vegetable" ||
                food.GetType().Name == "Fruit")
            {
                this.FoodEaten = food.Quantity;
                this.Weight += food.Quantity * mouseIncreaseFactor;
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
