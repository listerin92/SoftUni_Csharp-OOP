using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace BirthdayCelebrations
{
    public abstract class Identification : ICommon
    {
        private DateTime birthday;
        private string name;
        private int age;
        private string id;

        protected Identification(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        protected Identification(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        protected Identification(string name, int age, string id, DateTime birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age could not be negative!");
                }
                this.age = value;
            }
        }

        public string Id
        {
            get => this.id;
            private set
            {
                if (value.Any(char.IsLetter) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Not a valid ID!");
                }
                this.id = value;
            }
        }
        public DateTime Birthday
        {
            get => this.birthday;
            private set
            {
                DateTime date;
                bool validate = DateTime.TryParse(
                    value.ToString(),
                    out date);
                //Regex reg = new Regex(@"\d{2}\/\d{2}\/\d{4}");
                if (!validate)
                {
                    throw new ArgumentException("Not a valid Birthday!");
                }
                this.birthday = value;
            }
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Name should be at least 1 symbol long!");
                }
                this.name = value;
            }
        }
    }
}