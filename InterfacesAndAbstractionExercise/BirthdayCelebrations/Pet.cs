using System;
using System.Text.RegularExpressions;

namespace BirthdayCelebrations
{
    public class Pet : Identification
    {
        private string birthday;

        public Pet(string name, string birthday) : base(name, birthday)
        {
        }
    }
}