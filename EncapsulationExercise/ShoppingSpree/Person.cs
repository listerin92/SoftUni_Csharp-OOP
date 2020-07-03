namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public IReadOnlyList<Product> BagOfProducts => this.bagOfProducts;
        
        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void Add(Product product)
        {
            this.bagOfProducts.Add(product);
        }
        //public override string ToString()
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.Append($"Name: {this.Name}, Money: {this.Money}");

        //    return stringBuilder.ToString();
        //}

    }
}
