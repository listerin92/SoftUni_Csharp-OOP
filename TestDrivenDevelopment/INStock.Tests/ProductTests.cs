using System;

namespace INStock.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void QuantityCannotBeLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product("Test Product Label", 10m, -1);
            }, "Quantity cannot be less than zero.");
        }

        [Test]
        public void LabelCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product(null, 10m, -1);
            }, "Label cannot be null or empty.");
        }
        [Test]
        public void LabelCannotBeEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product("", 10m, -1);
            }, "Label cannot be null or empty.");
        }
        [Test]
        public void PriceCannotBeLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var product = new Product("Test", -10m, -1);
            }, "Price cannot be less than zero.");
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsCorrect()
        {
            var firstProduct = new Product("Test 1", 10m, 1);
            var secondProduct = new Product("Test 2", 5m, 1);

            var correctOrderResult = secondProduct.CompareTo(firstProduct);

            Assert.That(correctOrderResult < 0, Is.True);
        }
        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsIncorrect()
        {
            var firstProduct = new Product("Test 1", 10m, 1);
            var secondProduct = new Product("Test 2", 5m, 1);

            var incorrectOrder = secondProduct.CompareTo(firstProduct);

            Assert.That(incorrectOrder < 0, Is.True);
        }
        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsEqual()
        {
            var firstProduct = new Product("Test 1", 5m, 1);
            var secondProduct = new Product("Test 2" , 5m, 1);

            var equalOrderResult = firstProduct.CompareTo(secondProduct);

            Assert.That(equalOrderResult == 0, Is.True);
        }
    }
}