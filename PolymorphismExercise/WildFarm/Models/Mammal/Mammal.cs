using WildFarm.Models.Animals;
using WildFarm.Models.Mammal.Contracts;

namespace WildFarm.Models.Mammal
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight) : base(name, weight)
        {
            
        }
        public string LivingRegion { get; set; }
    }
}
