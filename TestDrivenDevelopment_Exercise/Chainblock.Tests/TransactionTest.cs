using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTest
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            Assert.AreEqual( id, transaction.Id);
            Assert.AreEqual(ts, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }
        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void IDCouldNotBeZeroOrNegative(int id)
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            Assert.That(() =>
            {
                ITransaction dummy = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException
                .With.Message
                .EqualTo(ExceptionMessages.InvalidIDMessage));

        }
        [Test]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        public void TestWithInvalidSenderName(string from)
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string to = "Gosho";
            double amount = 15;
            Assert.That(() =>
            {
                ITransaction dummy = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException
                .With.Message
                .EqualTo(ExceptionMessages.InvalidSenderUserNameMessage));
        }
        [Test]
        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        public void InvalidReceiverName(string to)
        {
            int id = 1;
            string from = "Pesho";
            TransactionStatus ts = TransactionStatus.Successfull;
            double amount = 15;
            Assert.That(() =>
            {
                ITransaction dummy = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException
                .With.Message
                .EqualTo(ExceptionMessages.InvalidReceiverUserNameMessage));
        }

        [Test]
        [TestCase(-10.0)]
        [TestCase(-0.000001)]
        [TestCase(0.0)]
        public void AmmountInvalidAmmountException(double amount)
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            Assert.That(() =>
            {
                ITransaction dummy = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException
                .With.Message
                .EqualTo(ExceptionMessages.InvalidTransactionAmountMessage));

        }
    }
}