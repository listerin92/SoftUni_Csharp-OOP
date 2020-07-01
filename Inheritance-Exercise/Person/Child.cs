using System;

namespace Person
{
    public class Child : Person
    {
        private int _age;

        public Child(string name, int age) : base(name, age)
        {

        }

        public override int Age
        {
            get => _age;
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException();
                }
                _age = value;
            }
        }
    }
}
