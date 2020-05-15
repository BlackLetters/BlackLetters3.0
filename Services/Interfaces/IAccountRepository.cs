using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Interfaces
{
    public interface IAccountRepository: IRepositoryBase<Account>
    {
        public bool AccountExists(int id);
    }
}
