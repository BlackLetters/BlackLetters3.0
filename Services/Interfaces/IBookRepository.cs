using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        public bool BookExists(int id);
    }
}
