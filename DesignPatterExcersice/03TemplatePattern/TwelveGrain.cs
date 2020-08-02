using System;

namespace _03TemplatePattern
{
    public class TwelveGrain : Bread
    {
        protected override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-Grain Bread.");
        }

        protected override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }
    }
}
