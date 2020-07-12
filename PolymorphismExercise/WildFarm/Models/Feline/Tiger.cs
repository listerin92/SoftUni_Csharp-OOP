using System;
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

        public override void Feed(Food.Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.FoodEaten = food.Quantity;
                this.Weight += food.Quantity * tigerIncreaseFactor;
            }
            else
            {
                string msg = string.Format(ExceptionMessages.InvalidFoodExceptionMessage, this.GetType().Name, food.GetType().Name);
                throw new InvalidOperationException(msg);
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
