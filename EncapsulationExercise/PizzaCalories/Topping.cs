using System;

namespace PizzaCalories
{
    public class Topping : Ingredient
    {
        private decimal weight;
        private string toppingType;

        public Topping(string toppingType, decimal weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;

            switch (this.toppingType.ToLower())
            {
                case "meat":
                    this.Modifier = 1.2m;
                    break;
                case "veggies":
                    this.Modifier = 0.8m;
                    break;
                case "cheese":
                    this.Modifier = 1.1m;
                    break;
                case "sauce":
                    this.Modifier = 0.9m;
                    break;
            }
        }
        public string ToppingType
        {
            set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public sealed override decimal Weight
        {
            get => this.weight;
            protected set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }
    }
}
