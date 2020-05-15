using Biblioteca.Models;
using Biblioteca.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.ImplementationServices
{
    public class TransactionService
    {
        private IRepositoryWrapper _repo;

        public TransactionService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public List<Transaction> GetAllTransactions()
        {
            return this._repo.Transaction.FindAll();
        }

        public Transaction GetDetailsById(int? id)
        {
            return _repo.Transaction.FindByCondition(m => m.ID == id);
        }

        public void Create(Transaction transaction)
        {
            _repo.Transaction.Create(transaction);
            _repo.Save();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _repo.Transaction.Update(transaction);
            _repo.Save();
        }
        public bool TransactionExists(int id)
        {
            bool found = _repo.Transaction.TransactionExists(id);
            return found;
        }
        public void DeleteTransaction(int id)
        {
            var transaction = _repo.Transaction.FindByCondition(m => m.ID == id);
            _repo.Transaction.Delete(transaction);

            _repo.Save();
        }
    }
}
