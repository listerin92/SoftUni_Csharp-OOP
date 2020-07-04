namespace PizzaCalories
{
    public abstract class Ingredient
    {
        protected const decimal BASE_CALORIES = 2.0m;

        public abstract decimal Weight { get; protected set; }

        public decimal AllModifiers => BASE_CALORIES * this.Modifier;

        protected decimal Modifier { get; set; }
    }
}