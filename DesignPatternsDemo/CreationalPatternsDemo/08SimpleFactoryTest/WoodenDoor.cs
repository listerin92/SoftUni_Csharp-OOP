using System.Text;

namespace _08SimpleFactoryForHumans
{
    public class WoodenDoor : IDoor
    {
        private readonly int height;
        private readonly int width;

        public WoodenDoor(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public int GetHeight()
        {
            return this.height;
        }
        public int GetWidth()
        {
            return this.width;
        }
    }
}