using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BirthdayCelebrations
{
    public class Citizen : Identification, IBirthable
    {
        private string id;
        private string birthday;
        private ICollection<IBirthable> birthdates;

        public Citizen(string name, int age, string id, DateTime birthday)
        : base(name, age, id, birthday) 
        {
            this.birthdates = new List<IBirthable>();
        }
        public IReadOnlyCollection<IBirthable> Repairs => (IReadOnlyCollection<IBirthable>)this.birthdates;
        public void AddBirthday(IBirthable birthday)
        {
            this.birthdates.Add(birthday);
        }
        public string GetBirthDay()
        {
            return this.Birthday.Date.ToString("dd\\/MM\\/yyyy");
        }
    }
}