using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start { get; } = "Engine start";
        public string Stop { get; } = "Breaaak!";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {nameof(Seat)} {this.Model}");
            sb.AppendLine(this.Start);
            sb.AppendLine(this.Stop);
            return sb.ToString().TrimEnd();
        }
    }
}
