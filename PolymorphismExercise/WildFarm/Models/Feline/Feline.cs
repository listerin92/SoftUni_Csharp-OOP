namespace WildFarm.Models.Feline
{
    public abstract class Feline : Mammal.Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
            this.Breed = breed;
        }
        public string Breed { get; set; }
    }
}
