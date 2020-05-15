using Biblioteca.Models;
using Biblioteca.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.ImplementationServices
{
    public class AccountService
    {
        private IRepositoryWrapper _repo;

        public AccountService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public List<Account> GetAllAccounts()
        {
            return this._repo.Account.FindAll();
        }

        public Account GetDetailsById(int? id)
        {
            return _repo.Account.FindByCondition(m => m.ID == id);
        }

        public void Create(Account account)
        {
            _repo.Account.Create(account);
            _repo.Save();
        }

        public void UpdateAccount(Account account)
        {
            _repo.Account.Update(account);
            _repo.Save();
        }
        public bool AccountExists(int id)
        {
            bool found = _repo.Account.AccountExists(id);
            return found;
        }
        public void DeleteAccount(int id)
        {
            var account = _repo.Account.FindByCondition(m => m.ID == id);
            _repo.Account.Delete(account);

            _repo.Save();
        }
    }
}
