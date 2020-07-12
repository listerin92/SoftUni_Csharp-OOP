using WildFarm.Models.Contracts;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; set; }
        public abstract double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public virtual string AskForFood()
        {
            return $"Animal";
        }

        public virtual void Feed(Food.Food food)
        {
            this.Weight += food.Quantity;
        }
    }
}
