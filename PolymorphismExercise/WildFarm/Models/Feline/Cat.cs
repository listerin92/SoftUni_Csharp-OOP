using System;
using WildFarm.Exceptions;

namespace WildFarm.Models.Feline
{
    public class Cat : Feline
    {
        private double weight;
        private const double catIncreaseFactor = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double Weight
        {
            get => this.weight;
            protected set
            {
                this.weight = value;
            }
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Feed(Food.Food food)
        {
            if (food.GetType().Name == "Vegetable" ||
                food.GetType().Name == "Meat")
            {
                this.FoodEaten = food.Quantity;
                this.Weight += food.Quantity * catIncreaseFactor;
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
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
