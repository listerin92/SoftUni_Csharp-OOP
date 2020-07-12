using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingsize)
            : base(name, weight)

        {
            this.WingSize = wingsize;
        }
        public double WingSize { get; private set; }
        public override double Weight { get; protected set; }

    }
}
