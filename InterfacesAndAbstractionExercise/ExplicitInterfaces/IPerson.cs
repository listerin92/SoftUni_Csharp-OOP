namespace ExplicitInterfaces
{
   public interface IPerson
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string GetName();
    }
}
