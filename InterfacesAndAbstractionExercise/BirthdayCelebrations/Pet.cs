using System;
using System.Text.RegularExpressions;

namespace BirthdayCelebrations
{
    public class Pet : Identification, IBirthable 
    {
        private string birthday;

        public Pet(string name, DateTime birthday) : base(name, birthday)
        {
        }

        public string GetBirthDay()
        {
            return this.Birthday.Date.ToString("dd\\/MM\\/yyyy");
        }
    }
}