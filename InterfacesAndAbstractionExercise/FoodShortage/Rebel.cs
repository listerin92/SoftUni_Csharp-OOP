using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : Identification, IBuyer
    {
        private int food = 0;

        public Rebel(string name, int age, string group) : base(name, age, group)
        {


        }

        public int Food
        {
            get => this.food;
            set
            {
                this.food = value;
            }
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}