using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(5, 5);
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());
            Circle circle = new Circle(5);
            Console.WriteLine($"{circle.CalculateArea():f2}");
            Console.WriteLine($"{circle.CalculatePerimeter():f2}");
            Console.WriteLine(circle.Draw());
        }
    }
}
