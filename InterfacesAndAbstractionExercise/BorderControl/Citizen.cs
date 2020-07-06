using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Citizen : IIdentification
    {
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Id
        {
            get => this.id;
            set
            {
                if (value.Any(char.IsLetter))
                {
                    throw new ArgumentException("Not a valid ID!");
                }
                this.id = value;
            }
        }
    }
}