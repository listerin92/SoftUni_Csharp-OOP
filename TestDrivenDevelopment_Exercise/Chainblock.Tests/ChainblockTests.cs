using System.Collections.Generic;
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
        public void TestRemoveTransactionByIdThrowException()
        {
            ITransaction transaction = new Transaction(1, TransactionStatus.Failed, "Pesho", "Gosho", 10.0);
            this.chainblock.Add(transaction);
            Assert.That(() =>
            {
                this.chainblock.RemoveTransactionById(3);

            }, Throws.InvalidOperationException
                .With.Message
                .EqualTo(ExceptionMessages
                    .RemovingNonExistingTransactionMessage));
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
        [Test]
        public void GetByStatusShouldCorrectTransaction()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                var ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10.0;
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currentTransaction);
                }
                this.chainblock.Add(currentTransaction);
            }
            ITransaction succTr = new Transaction(4, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(succTr);
            expTransactions = expTransactions.OrderByDescending(tx => tx.Amount).ToList();

            this.chainblock.Add(succTr);

            IEnumerable<ITransaction> actTransactions = this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }
        [Test]
        public void GettingTransactionsWithNoExistingStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10.0 + i;
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currentTransaction);
            }
            Assert.That(() =>
            {
                this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException
                .With.Message
                .EqualTo(ExceptionMessages
                    .NotExistingTransactionMessage));
        }
        [Test]
        public void GettingAllSendersWithTransactionStatus()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                var ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10.0;
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currentTransaction);
                }
                this.chainblock.Add(currentTransaction);
            }
            ITransaction succTr = new Transaction(4, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(succTr);
            this.chainblock.Add(succTr);
            var actTransactions = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<string> expTransactionOut = expTransactions
                .OrderByDescending(x => x.Amount)
                .Select(tx => tx.From);
            CollectionAssert.AreEqual(expTransactionOut, actTransactions);
        }
        [Test]
        public void AllSendersByStatusThrowExceptionWhenNoTransactionItTheGivenStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10.0 + i;
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currentTransaction);
            }
            Assert.That(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException
                .With.Message
                .EqualTo(ExceptionMessages
                    .NotExistingTransactionMessage));
        }

        [Test]
        public void GettingAllReceiversWithTransactionStatus()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                var ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10.0;
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currentTransaction);
                }
                this.chainblock.Add(currentTransaction);
            }
            ITransaction succTr = new Transaction(4, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(succTr);
            this.chainblock.Add(succTr);
            var actTransactions = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<string> expTransactionOut = expTransactions
                .OrderByDescending(x => x.Amount)
                .Select(tx => tx.To);
            CollectionAssert.AreEqual(expTransactionOut, actTransactions);
        }
        [Test]
        public void AllReceiversByStatusThrowExceptionWhenNoTransactionItTheGivenStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10.0 + i;
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainblock.Add(currentTransaction);
            }
            Assert.That(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException
                .With.Message
                .EqualTo(ExceptionMessages
                    .NoTransactionInCollectionMessage));
        }
        [Test]
        public void GettingAllOrderByAmountThenById()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                var ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10.0 *(i+1);
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                    expTransactions.Add(currentTransaction);
                this.chainblock.Add(currentTransaction);
            }
            var actTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            IEnumerable<ITransaction> expTransactionOut = expTransactions
                .OrderByDescending(x => x.Amount)
                .ThenBy(tr => tr.Id);
            CollectionAssert.AreEqual(expTransactionOut, actTransactions);
        }
        [Test]
        public void GettingAllOrderByAmountThenByIdThrowExceptionWhenNoTransaction()
        {
            Assert.That(() =>
            {
                this.chainblock.GetAllOrderedByAmountDescendingThenById();
            }, Throws.InvalidOperationException
                .With.Message
                .EqualTo(ExceptionMessages
                    .NoTransactionInCollectionMessage));
        }
        [Test]
        public void GetBySenderOrderedByAmountDescendingCorrect()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                var ts = (TransactionStatus)i;
                string from = "Pesho";
                string to = "Gosho" + i;
                double amount = 10.0 * (i + 1);
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                expTransactions.Add(currentTransaction);

                this.chainblock.Add(currentTransaction);
            }
            ITransaction lastOne = new Transaction(4, TransactionStatus.Successfull, "Ivan", "Gosho4", 40.0);
            expTransactions.Add(lastOne);
            this.chainblock.Add(lastOne);

            var actTransactions = this.chainblock.GetBySenderOrderedByAmountDescending("Pesho");

            IEnumerable<ITransaction> expTransactionOut = expTransactions
                .Where(tr => tr.From == "Pesho")
                .OrderByDescending(x => x.Amount)
                .ThenBy(tr => tr.Id);
            CollectionAssert.AreEqual(expTransactionOut, actTransactions);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdCorrect()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                var ts = (TransactionStatus)i;
                string from = "Pesho"+i;
                string to = "Gosho";
                double amount = 10.0 * (i + 1);
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                expTransactions.Add(currentTransaction);

                this.chainblock.Add(currentTransaction);
            }
            ITransaction lastOne = new Transaction(4, TransactionStatus.Successfull, "Ivan", "Gosho4", 40.0);
            expTransactions.Add(lastOne);
            this.chainblock.Add(lastOne);

            var actTransactions = this.chainblock.GetByReceiverOrderedByAmountThenById("Gosho");

            IEnumerable<ITransaction> expTransactionOut = expTransactions
                .Where(tx => tx.To == "Gosho")
                .OrderByDescending(tx => tx.Amount);
            CollectionAssert.AreEqual(expTransactionOut, actTransactions);
        }

        [Test]
        public void TestChainblockEnumerator()
        {
            ICollection<ITransaction> addTr = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                var ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho";
                double amount = 10.0 * (i + 1);
                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                addTr.Add(currentTransaction);

                this.chainblock.Add(currentTransaction);
            }
            ICollection<ITransaction> actTr = new List<ITransaction>();

            foreach (var tr in this.chainblock)
            {
                actTr.Add(tr);
            }

            CollectionAssert.AreEqual(addTr, actTr);
        }
    }
}