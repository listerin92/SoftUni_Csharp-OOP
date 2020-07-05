using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public abstract class Car
    {
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Start { get; } = "Engine start";
        public string Stop { get; } = "Breaaak!";
    }
}
