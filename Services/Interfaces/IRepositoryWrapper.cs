using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Interfaces
{
    public interface IRepositoryWrapper
    {

        public IBookRepository Book { get; }
        public ITransactionRepository Transaction { get; }
        public IAccountRepository Account { get; }
        public void Save();
    }
}
