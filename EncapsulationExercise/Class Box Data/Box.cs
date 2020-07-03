using System;

namespace Class_Box_Data
{
    public class Box
    {
        private double height;
        private double width;
        private double length;
        private const int SIDE_MIN_VALUE = 0;
        private const string INVALID_SIDE_MESSAGE = "{0} cannot be zero or negative.";

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get => this.length;
            private set
            {
                ValidateState(value, nameof(this.Length));
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                ValidateState(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                ValidateState(value, nameof(this.Height));
                this.height = value;
            }
        }

        private void ValidateState(double value, string name)
        {
            if (value <= SIDE_MIN_VALUE)
            {
                throw new ArgumentException(String.Format(INVALID_SIDE_MESSAGE, name));
            }
        }

        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return 2 * this.length * this.width
                   + 2 * this.length * this.height +
                   2 * this.width * this.height;
        }

        public double LateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            return 2 * this.length * this.height
                   + 2 * this.width * this.height;
        }

        public double Volume()
        {
            //Volume = lwh
            return this.length * this.width * this.height;
        }
    }
}
