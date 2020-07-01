using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public virtual int Age
        {
            get => _age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                _age = value;
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");

            return stringBuilder.ToString();
        }

    }
}
