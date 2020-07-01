using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Snake snake = new Snake("Zmiichoka");
            Console.WriteLine(snake.Name);
            Lizard lizard = new Lizard("Gushtera");
            Console.WriteLine(lizard.Name);
            Gorilla gorila = new Gorilla("Mamunata");
            Console.WriteLine(gorila.Name);
            Bear bear = new Bear("Mechkata");
            Console.WriteLine(bear.Name);
            Reptile rept = new Reptile("Vlechugoto");
            Console.WriteLine(rept.Name);
            Mammal mammal = new Mammal("Mamala");
            Console.WriteLine(mammal.Name);
            Animal animal = new Animal("Zivotnoto");
            Console.WriteLine(animal.Name);
        }
    }
}