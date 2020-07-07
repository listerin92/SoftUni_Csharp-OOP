using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoodShortage
{
    public class Citizen : Identification, IBuyer
    {
        private string id;
        private string birthday;
        private int food = 0;

        public Citizen(string name, int age, string id, DateTime birthday)
        : base(name, age, id, birthday)
        {
        }

        public string GetBirthDay()
        {
            return this.Birthday.Date.ToString("dd\\/MM\\/yyyy");
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
            this.Food += 10;
        }
    }
}