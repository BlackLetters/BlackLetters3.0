using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Services.Interfaces;
using Biblioteca.Services.ImplementationServices;

namespace Biblioteca.Controllers
{
    public class BooksController : Controller
    {
        //private readonly BibliotecaContext _context;
        //private readonly IRepositoryWrapper repo;
        private readonly BookService bookService;

        public BooksController(BookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: Books
        public IActionResult Index()
        {
            //var book = repo.Book.FindAll();
            var book = bookService.GetAllBooks();
            return View(book);
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var book = repo.Book.FindByCondition((System.Linq.Expressions.Expression<Func<Book, bool>>)(t => t.ID == id));
            var book = bookService.GetDetailsById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Title,Price,Status,Type,Author")] Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.Create(book);
                //repo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var book = repo.Book.FindByCondition((System.Linq.Expressions.Expression<Func<Book, bool>>)(t => t.ID == id));
            var book = bookService.GetDetailsById(id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Title,Price,Status,Type,Author")] Book book)
        {
            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //repo.Book.Update(book);
                    //repo.Save();
                    bookService.UpdateBook(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bookService.BookExists(book.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var book = repo.Book.FindByCondition((System.Linq.Expressions.Expression<Func<Book, bool>>)(t => t.ID == id));
            var book = bookService.GetDetailsById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //var book = repo.Book.FindByCondition((System.Linq.Expressions.Expression<Func<Book, bool>>)(t => t.ID == id));
            //repo.Book.Delete(book);
            //repo.Save();
            bookService.DeleteBook(id);

            return RedirectToAction(nameof(Index));
        }

        //private bool BookExists(int id)
        //{
        //    bool found = repo.Book.BookExists(id);
        //    return found;
        //}
    }
}
