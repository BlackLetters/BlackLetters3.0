using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Interfaces
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        public bool TransactionExists(int id);
    }
}
