using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly BibliotecaContext repoContext;

        private IBookRepository _book;
        private ITransactionRepository _transaction;
        private IAccountRepository _account;

        public RepositoryWrapper(BibliotecaContext repositoryContext)
        {
            repoContext = repositoryContext;
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(repoContext);
                }

                return _book;
            }
        }

        public ITransactionRepository Transaction
        {
            get
            {
                if (_transaction == null)
                {
                    _transaction = new TransactionRepository(repoContext);
                }

                return _transaction;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(repoContext);
                }

                return _account;
            }
        }

        public void Save()
        {
            repoContext.SaveChanges();
        }
    }
}
