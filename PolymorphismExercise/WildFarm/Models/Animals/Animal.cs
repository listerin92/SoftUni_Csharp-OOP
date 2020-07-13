using System;
using System.Collections.Generic;
using WildFarm.Exceptions;
using WildFarm.Models.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; set; }
        public abstract double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract double WeightMultiplier { get; }
        public abstract ICollection<Type> PreferredFoods { get; }
        public virtual string AskForFood()
        {
            return $"Animal";
        }

        public virtual void Feed(Food.Food food)
        {
            if (!PreferredFoods.Contains(food.GetType()))
            {
                string msg = string.Format(ExceptionMessages.InvalidFoodExceptionMessage
                    , this.GetType().Name
                    , food.GetType().Name);
                throw new InvalidOperationException(msg);
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }
    }
}
