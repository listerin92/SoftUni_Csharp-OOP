using System.Collections.Generic;

namespace _01Prototype
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }
        public SandwichPrototype this[string name]
        {
            get => this.sandwiches[name];
            set => this.sandwiches.Add(name, value);
        }
    }
}
