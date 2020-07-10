using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        private double Radius
        {
            get => radius;
            set => radius = value;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override string Draw()
        {
            return base.Draw() + " " + nameof(Circle);
        }
    }
}
