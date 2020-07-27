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
            throw new System.NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
