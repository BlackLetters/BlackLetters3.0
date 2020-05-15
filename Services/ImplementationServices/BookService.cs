using Biblioteca.Models;
using Biblioteca.Services.Interfaces;
using Biblioteca.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Services.ImplementationServices
{
    public class BookService
    {
        private IRepositoryWrapper _repo;

        public BookService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }

        public List<Book> GetAllBooks()
        {
            return this.GetBookRepository().FindAll();
        }
            
        public Book GetDetailsById(int? id)
        {
            return _repo.Book.FindByCondition(m => m.ID == id);
        }

        public void Create(Book book)
        {
            _repo.Book.Create(book);
            _repo.Save();
        }

        public void UpdateBook(Book book)
        {
            _repo.Book.Update(book);
            _repo.Save();
        }
        public bool BookExists(int id)
        {
            bool found = _repo.Book.BookExists(id);
            return found;
        }
        public void DeleteBook(int id)
        {
            var book = _repo.Book.FindByCondition(m => m.ID == id);
            _repo.Book.Delete(book);

            _repo.Save();
        }

        public IBookRepository GetBookRepository()
        {
            return _repo.Book;
        }
    }
}
