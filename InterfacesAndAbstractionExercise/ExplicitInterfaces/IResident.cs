namespace ExplicitInterfaces
{
    public interface IResident
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string GetName();
    }
}
