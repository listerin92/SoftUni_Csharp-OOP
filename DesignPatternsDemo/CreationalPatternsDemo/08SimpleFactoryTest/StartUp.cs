using System;

namespace _08SimpleFactoryForHumans
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var door = DoorFactory.MakeDoor(80, 30);
            Console.WriteLine($"Height of Door : {door.GetHeight()}");
            Console.WriteLine($"Width of Door : {door.GetWidth()}");
        }
    }
}
