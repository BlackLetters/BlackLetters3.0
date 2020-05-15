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
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BibliotecaContext repositoryContext)
            : base(repositoryContext)
        {

        }
        
        public bool BookExists(int id)
        {
            var found = RepositoryContext.Books.Any(e => e.ID == id);
            return found;
        }
    }
}
