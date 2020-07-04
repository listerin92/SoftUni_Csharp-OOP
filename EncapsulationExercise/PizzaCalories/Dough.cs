using System;

namespace PizzaCalories
{
    public class Dough : Ingredient
    {
        private string flourType;
        private string bakingTechnique;
        private decimal weight;
        private const decimal white = 1.5m;
        private const decimal wholegrain = 1.0m;
        private const decimal crispy = 0.9m;
        private const decimal chewy = 1.1m;
        private const decimal homemade = 1.0m;
        private const string INVALID_DOUGH = "Invalid type of dough.";
        public Dough(string flourType, string bakingTechnique, decimal weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;

            this.Modifier = flourType.ToLower() switch
            {
                "white" => white,
                "wholegrain" => wholegrain,
                _ => this.Modifier
            };

            //multiply flourType modifier with baking technique modifier
            this.Modifier *= bakingTechnique.ToLower() switch 
            {
                "crispy" => crispy,
                "chewy" => chewy,
                "homemade" => homemade,
                _ => this.Modifier
            };
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" 
                    && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(INVALID_DOUGH);
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" 
                    && value.ToLower() != "chewy" 
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(INVALID_DOUGH);
                }
                this.bakingTechnique = value;
            }
        }

        public sealed override decimal Weight
        {
            get => this.weight;
            protected set
            {
                if (value < 1 && value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

    }
}