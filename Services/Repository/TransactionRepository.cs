using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Biblioteca.Services.Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(BibliotecaContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public bool TransactionExists(int id)
        {
            var found = RepositoryContext.Transactions.Any(e => e.ID == id);
            return found;
        }

        //public Transaction FindByCondition(Expression<Func<Transaction, bool>> expression)
        //{
        //    return this.RepositoryContext.Transactions
        //        .Include(t => t.Account)
        //        .Where(expression)
        //        .FirstOrDefault();
        //}

        //public List<Account> FindAll()
        //{
        //    return this.RepositoryContext.Transactions
        //        .Include(t => t.Account)
        //        .ToList();
        //}
    }
}
