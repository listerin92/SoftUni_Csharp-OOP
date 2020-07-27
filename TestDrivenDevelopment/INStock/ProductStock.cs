using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private readonly HashSet<string> productLabels;
        private readonly List<IProduct> productsByIndex;
        private readonly Dictionary<string, IProduct> productByLabel;
        private readonly Dictionary<int, List<IProduct>> productsByQuantity;
        private readonly SortedDictionary<decimal, List<IProduct>> productSortedByPrice;

        public ProductStock()
        {
            this.productLabels = new HashSet<string>();
            this.productsByIndex = new List<IProduct>();
            this.productByLabel = new Dictionary<string, IProduct>();
            this.productsByQuantity = new Dictionary<int, List<IProduct>>();
            this.productSortedByPrice = new SortedDictionary<decimal, List<IProduct>>(Comparer<decimal>
                .Create((first, second) => second.CompareTo(first))); //OppositeSort
        }

        public int Count => this.productsByIndex.Count;

        public bool Contains(IProduct product)
        {
            ValidateNullProduct(product);
            return this.productLabels.Contains(product.Label);
        }


        public void Add(IProduct product)
        {
            ValidateNullProduct(product);

            if (productLabels.Contains(product.Label))
            {
                throw new ArgumentException($"A product with {product.Label} label already exist.");
            }

            InitializeCollections(product);

            this.productLabels.Add(product.Label);
            this.productsByIndex.Add(product);
            this.productByLabel.Add(product.Label, product);
            this.productsByQuantity[product.Quantity].Add(product);
            this.productSortedByPrice[product.Price].Add(product);
        }

        public bool Remove(IProduct product)
        {
            ValidateNullProduct(product);
            if (!this.productLabels.Contains(product.Label))
            {
                return false;
            }

            this.productsByIndex.RemoveAll(pr => pr.Label == product.Label);
            RemoveProductFromCollections(product);

            return true;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.productsByIndex.Count)
            {
                throw new IndexOutOfRangeException("Product index does not exist");
            }
            return this.productsByIndex[index];
        }

        public IProduct FindByLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentException("Product label could not be null");
            }
            if (!productByLabel.ContainsKey(label))
            {
                throw new ArgumentException("Product label could not be found");
            }

            return productByLabel[label];
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (!this.productSortedByPrice.Any())
            {
                throw new ArgumentException("Product stock is empty");
            }

            var mostExpensiveProducts = this.productSortedByPrice.First().Value;
            var firstAddedExpensiveProduct = mostExpensiveProducts.First();
            return firstAddedExpensiveProduct;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            var result = new List<IProduct>();
            foreach (var (price, products) in this.productSortedByPrice)
            {
                var priceAsDouble = (double)price;
                if (lo <= priceAsDouble && priceAsDouble <= hi)
                {
                    result.AddRange(products);
                }

                if (priceAsDouble < lo)
                {
                    break;
                }
            }
            return result;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            return !this.productSortedByPrice.ContainsKey((decimal)price)
                ? Enumerable.Empty<IProduct>()
                : this.productSortedByPrice[(decimal)price];
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return !this.productsByQuantity.ContainsKey(quantity)
                ? Enumerable.Empty<IProduct>()
                : this.productsByQuantity[quantity];
        }

        public IEnumerator<IProduct> GetEnumerator()
            => this.productsByIndex.GetEnumerator();

        public IProduct this[int index]
        {
            get => this.Find(index);
            set
            {
                ValidateNullProduct(value);

                this.RemoveProductFromCollections(this.Find(index));

                this.InitializeCollections(value);

                this.productsByIndex[index] = value;
            }
        }
        private static void ValidateNullProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product could not be null");
            }
        }
        private void InitializeCollections(IProduct product)
        {
            if (!this.productsByQuantity.ContainsKey(product.Quantity))
            {
                this.productsByQuantity[product.Quantity] = new List<IProduct>();
            }
            if (!this.productSortedByPrice.ContainsKey(product.Price))
            {
                this.productSortedByPrice[product.Price] = new List<IProduct>();
            }
        }

        private void RemoveProductFromCollections(IProduct product)
        {
            this.productLabels.Remove(product.Label);
            //this.productsByIndex.RemoveAll(pr => pr.Label == product.Label);
            this.productByLabel.Remove(product.Label);

            var allWithProductQuantity = this.productsByQuantity[product.Quantity];
            allWithProductQuantity.RemoveAll(pr => pr.Label == product.Label);

            var allWithProductPrice = this.productSortedByPrice[product.Price];

            allWithProductPrice.RemoveAll(pr => pr.Label == product.Label);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}