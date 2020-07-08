using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BirthdayCelebrations
{
    public class Pet : Identification, IBirthable 
    {
        private string birthday;
        private ICollection<IBirthable> birthdates;

        public Pet(string name, DateTime birthday) : base(name, birthday)
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