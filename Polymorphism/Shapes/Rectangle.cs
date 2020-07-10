namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }


        private double Width
        {
            get => this.width;
            set => this.width = value;
        }

        private double Height
        {
            get => this.height;
            set => this.height = value;
        }

        public override double CalculatePerimeter()
        {
            return this.width * 2 + this.height * 2;
        }

        public override double CalculateArea()
        {
            return this.width * this.height;
        }

        public override string Draw()
        {
            return base.Draw() + " " + nameof(Rectangle);
        }
    }
}