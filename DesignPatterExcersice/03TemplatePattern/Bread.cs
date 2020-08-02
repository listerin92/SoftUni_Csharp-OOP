using System;

namespace _03TemplatePattern
{
    public abstract class Bread
    {
        protected abstract void MixIngredients();
        protected abstract void Bake();

        protected virtual void Slice()
        {
            Console.WriteLine("Slicing the " + GetType().Name + "bread!");
        }

        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}