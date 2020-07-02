using System;
using static PersonsInfo.CommonValidator;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        private const int MinimumNameLength = 3;
        private const int MinimumSalary = 460;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                ValidateLength(value, MinimumNameLength, nameof(Person), nameof(this.FirstName));

                this.firstName = value;

            }
        }

        public string LastName
        {
            get => this.lastName;

            private set
            {
                ValidateLength(value, MinimumNameLength, nameof(Person), nameof(this.LastName));
                
                this.lastName = value;

            }
        }

        public int Age
        {
            get => this.age;

            private set
            {

                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age = value;
            }
        }

        public decimal Salary
        {
            get => this.salary;
            private set
            {
                ValidateNull(value, nameof(Person), nameof(this.Salary));
                ValidateMinimum(value, MinimumSalary, nameof(Person), nameof(this.Salary));
                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            SetSalary(percentage, this.Age > 30 ? 100 : 200);
        }

        private void SetSalary(decimal percentage, int ageMod)
        {
            this.Salary += this.Salary * percentage / ageMod;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
    }
}
