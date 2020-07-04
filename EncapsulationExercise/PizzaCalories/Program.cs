using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine()
                    .Split(' ');
                string[] doughArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var flourType = doughArgs[1];
                var bakingTechnique = doughArgs[2];
                var weight = decimal.Parse(doughArgs[3]);
                
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                List<Topping> toppings = new List<Topping>();
                
                var pizza = new Pizza(pizzaName[1], dough);
                
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingArgs = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Topping topping = 
                        new Topping(toppingArgs[1], decimal.Parse(toppingArgs[2]));
                    pizza.AddTopping(topping);
                }
               
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
