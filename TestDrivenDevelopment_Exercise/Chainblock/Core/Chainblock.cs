using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Chainblock.Common;
using Chainblock.Models;
using Chainblock.Contracts;

namespace Chainblock.Core
{
    public class Chainblock : IChainblock
    {
        private readonly ICollection<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }
        public int Count => this.transactions.Count;
        public void Add(ITransaction tx)
        {
            if (transactions.Contains(tx))
            {
                throw new InvalidOperationException(ExceptionMessages
                    .AddingExistingTransactionMessage);
            }
            this.transactions.Add(tx);
        }

        public bool Contains(ITransaction tx)
        {
            return this.Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            bool isContained = this.transactions.Any(x => x.Id == id);
            return isContained;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingTransactionMessage);
            }

            transaction.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            try
            {
                ITransaction transaction = this.GetById(id);
                this.transactions.Remove(transaction);
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException(ExceptionMessages.RemovingNonExistingTransactionMessage, ioe);
            }
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException(ExceptionMessages.NotExistingTransactionMessage);
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var transaction = this.transactions.Where(t => t.Status == status).OrderByDescending(tx => tx.Amount);
            if (!transaction.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NotExistingTransactionMessage);
            }

            return transaction;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var senderTransactions = this.GetByTransactionStatus(status)
                .Select(tx => tx.From);
            return senderTransactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var transaction = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(tx => tx.Amount)
                .Select(tx => tx.To);
            if (!transaction.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoTransactionInCollectionMessage);
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var transaction = this.transactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id);
            if (!transaction.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoTransactionInCollectionMessage);
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var transaction = this.transactions
                .Where(tx => tx.From == sender)
                .OrderByDescending(tx => tx.Amount);
            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var transaction = this.transactions
                .Where(tx => tx.To == receiver)
                .OrderByDescending(tx => tx.Amount);
            return transaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            var transaction = this.transactions
                .Where((txs) => txs.Status == status && txs.Amount <= amount)
                .OrderByDescending(tx => tx.Amount);

            return transaction;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.transactions.ToArray()[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}