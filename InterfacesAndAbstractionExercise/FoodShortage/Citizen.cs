using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoodShortage
{
    public class Citizen : Identification, IBirthable
    {
        private string id;
        private string birthday;

        public Citizen(string name, int age, string id, DateTime birthday)
        : base(name, age, id, birthday)
        {
        }

        public string GetBirthDay()
        {
            return this.Birthday.Date.ToString("dd\\/MM\\/yyyy");
        }
    }
}