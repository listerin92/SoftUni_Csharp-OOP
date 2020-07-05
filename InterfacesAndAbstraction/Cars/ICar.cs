namespace Cars
{
    public interface ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start { get; }
        public string Stop { get; }
    }
}