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
        private ITransaction testTransaction;
        [SetUp]
        public void Initializer()
        {
            chainblock = new Core.Chainblock();
            testTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 10.0);
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

        [Test]
        public void TestChangingTransactionStatusOfExistingTransaction()
        {
            TransactionStatus newStatus = TransactionStatus.Successfull;
            ITransaction transaction = new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 10.0);
            this.chainblock.Add(transaction);

            this.chainblock.ChangeTransactionStatus(1, newStatus);
            Assert.AreEqual(newStatus, transaction.Status);
        }
        [Test]
        public void TestChangingTransactionStatusOfNonExistingTransaction()
        {
            int fakeID = 222;
            TransactionStatus newStatus = TransactionStatus.Successfull;
            ITransaction transaction = new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 10.0);

            this.chainblock.Add(transaction);

            Assert.That(() =>
            {
                this.chainblock.ChangeTransactionStatus(fakeID, newStatus);

            }, Throws.ArgumentException
                .With.Message
                .EqualTo(ExceptionMessages
                    .NotExistingTransactionMessage));
        }

        [Test]
        public void TestRemoveTransactionById()
        {
            int id = 2;
            TransactionStatus status = TransactionStatus.Successfull;
            ITransaction transaction = new Transaction(id, status, "Sender", "Receiver", 20.0);

            this.chainblock.Add(this.testTransaction);
            this.chainblock.Add(transaction);
            this.chainblock.RemoveTransactionById(1);

            ITransaction returnTransaction = this.chainblock.GetById(id);

            Assert.That(returnTransaction.Id, Is.EqualTo(id));
            Assert.That(returnTransaction.Status, Is.EqualTo(status));
            Assert.That(returnTransaction.From, Is.EqualTo("Sender"));
            Assert.That(returnTransaction.To, Is.EqualTo("Receiver"));
            Assert.That(returnTransaction.Amount, Is.EqualTo(20.0));
        }

        [Test]
        public void GetByIDShouldThrowExceptionWhenNotFoundID()
        {
            int fakeId = 2;

            this.chainblock.Add(this.testTransaction);
            Assert.That(() =>
            {
                ITransaction returnTransaction = this.chainblock.GetById(fakeId);

            }, Throws.InvalidOperationException
                .With.Message
                .EqualTo(ExceptionMessages
                    .NotExistingTransactionMessage));
        }
        [Test]
        public void GetByIDShouldReturnCorrectTransaction()
        {
            int id = 2;
            TransactionStatus status = TransactionStatus.Successfull;
            ITransaction transaction = new Transaction(id, status, "Sender", "Receiver", 20.0);

            this.chainblock.Add(this.testTransaction);
            this.chainblock.Add(transaction);
            ITransaction returnTransaction = this.chainblock.GetById(id);

            Assert.That(returnTransaction.Id, Is.EqualTo(id));
            Assert.That(returnTransaction.Status, Is.EqualTo(status));
            Assert.That(returnTransaction.From, Is.EqualTo("Sender"));
            Assert.That(returnTransaction.To, Is.EqualTo("Receiver"));
            Assert.That(returnTransaction.Amount, Is.EqualTo(20.0));
        }
    }
}