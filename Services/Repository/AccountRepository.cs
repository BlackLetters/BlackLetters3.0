using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Biblioteca.Services.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(BibliotecaContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool AccountExists(int id)
        {
            var found = RepositoryContext.Transactions.Any(e => e.ID == id);
            return found;
        }

        public Account FindByCondition(Expression<Func<Account, bool>> expression)
        {
            return this.RepositoryContext.Accounts
                .Include(t => t.Book)
                .Include(t => t.Transaction)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<Account> FindAll()
        {
            return this.RepositoryContext.Accounts
                .Include(e => e.Book)
                .Include(t => t.Transaction)
                .ToList();
        }
    }
}
