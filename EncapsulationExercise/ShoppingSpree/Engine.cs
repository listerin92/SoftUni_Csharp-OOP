using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Engine
    {
        public void Run()
        {
            string[] lineOne =
                Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            string[] lineTwo =
                Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            string command = string.Empty;

            try
            {
                var persons = AddPersons(lineOne);
                var products = AddProducts(lineTwo);

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandToken = command.Split(' ').ToArray();
                    string name = commandToken[0];
                    string productToBuy = commandToken[1];

                    BuyProduct(persons, name, products, productToBuy);
                }

                PrintOutput(persons);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void PrintOutput(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person.BagOfProducts.Count == 0
                    ? $"{person.Name} - Nothing bought"
                    : $"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(x => x.Name))}");
            }
        }

        private static void BuyProduct(List<Person> persons, string name, List<Product> products, string productToBuy)
        {
            Person matchedPerson = persons.FirstOrDefault(x => x.Name == name);
            Product matchedProduct = products.FirstOrDefault(x => x.Name == productToBuy);
            if (matchedPerson.Money >= matchedProduct.Cost)
            {
                matchedPerson.Money -= matchedProduct.Cost;
                matchedPerson.Add(matchedProduct);
                Console.WriteLine($"{matchedPerson.Name} bought {matchedProduct.Name}");
            }
            else
            {
                Console.WriteLine($"{matchedPerson.Name} can't afford {matchedProduct.Name}");
            }
        }

        private static List<Product> AddProducts(string[] lineTwo)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < lineTwo.Length; i++)
            {
                string[] productCost = lineTwo[i].Split('=').ToArray();
                Product product = new Product(productCost[0], decimal.Parse(productCost[1]));
                products.Add(product);
            }

            return products;
        }

        private static List<Person> AddPersons(string[] lineOne)
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < lineOne.Length; i++)
            {
                string[] nameMoney = lineOne[i].Split("=").ToArray();
                Person person = new Person(nameMoney[0], decimal.Parse(nameMoney[1]));
                persons.Add(person);
            }

            return persons;
        }
    }
}