using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        private Dough Dough { get; }

        public IReadOnlyList<Topping> Toppings => this.toppings.AsReadOnly();

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        private decimal CalculateCalories()
        {
            var toppingsTotalCalories = GetTotalToppingsCalories(this.toppings);
            //AllModifiers is baseModifier*flourTypeModifier*bakingTypeModifier
            return (this.Dough.Weight * this.Dough.AllModifiers) + toppingsTotalCalories;
        }

        private static decimal GetTotalToppingsCalories(List<Topping> toppings)
        {
            return toppings.Sum(topping => topping.Weight * topping.AllModifiers);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateCalories():F2} Calories.";
        }
    }
}