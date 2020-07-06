using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BirthdayCelebrations
{
    public class Citizen : Identification
    {
        private string id;
        private string birthday;

        public Citizen(string name, int age, string id, string birthday)
        : base(name, age, id, birthday)
        {
        }
    }
}