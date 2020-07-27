using System.Linq;
using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Initializer()
        {
            chainblock = new Core.Chainblock();
        }
        [Test]
        public void IfConstructorWorksCorrectly()
        {
            int expectedInitialCount = 0;

            Assert.AreEqual(expectedInitialCount, chainblock.Count);
        }

        [Test]
        public void AddShouldIncreaseContWhenSucceed()
        {
            int expectedCount = 1;
            ITransaction transaction = new Transaction(5, TransactionStatus.Successfull, "Pesho", "Gosho", 10.0);
            this.chainblock.Add(transaction);
            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void AddingExistingTransactionTrowingException()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Failed, "Pesho", "Gosho", 10.0);
            this.chainblock.Add(transaction);
            Assert.That(() =>
            {
                this.chainblock.Add(transaction);

            }, Throws.InvalidOperationException
                .With.Message
                .EqualTo(ExceptionMessages
                    .AddingExistingTransactionMessage));
        }
        [Test]
        public void AddSAnotherTransactionWithAnotherIDShouldPass()
        {
            int expectedCount = 2;
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 10.0);
            ITransaction anotherTransaction = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gosho", 10.0);
            this.chainblock.Add(transaction);
            this.chainblock.Add(anotherTransaction);
            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void ContainsShouldReturnTrueWithExistingTransaction()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Failed, "Pesho", "Gosho", 10.0);
            this.chainblock.Add(transaction);

            Assert.IsTrue(this.chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsReturnFalseWithNonExistingTransaction()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Failed, "Pesho", "Gosho", 10.0);
            // this.chainblock.Add(transaction);

            Assert.IsFalse(this.chainblock.Contains(transaction));
        }
        [Test]
        public void ContainsByIDShouldReturnTrueWithExistingTransaction()
        {
            int id = 1;
            ITransaction transaction = new Transaction(id, TransactionStatus.Failed, "Pesho", "Gosho", 10.0);
            this.chainblock.Add(transaction);

            Assert.IsTrue(this.chainblock.Contains(id));
        }
        [Test]
        public void ContainsByIDShouldReturnFalseWithExistingTransaction()
        {
            int id = 1;
            ITransaction transaction = new Transaction(id, TransactionStatus.Failed, "Pesho", "Gosho", 10.0);
            //this.chainblock.Add(transaction);

            Assert.IsFalse(this.chainblock.Contains(id));
        }
    }
}