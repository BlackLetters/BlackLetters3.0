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
    public class TransactionsController : Controller
    {
        //private readonly BibliotecaContext _context;
        //private readonly IRepositoryWrapper repo;
        private readonly TransactionService transactionService;

        public TransactionsController(TransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Transactions.ToListAsync());
            var transaction = transactionService.GetAllTransactions();

            return View(transaction);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var transaction = await _context.Transactions
            //    .FirstOrDefaultAsync(m => m.ID == id);
            var transaction = transactionService.GetDetailsById(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,DateOfReturn,DateOfAquire")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                //repo.Transaction.Create(transaction);
                //repo.Save();
                transactionService.Create(transaction);

                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var transaction = await _context.Transactions.FindAsync(id);
            var transaction = transactionService.GetDetailsById(id);

            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateOfReturn,DateOfAquire")] Transaction transaction)
        {
            if (id != transaction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(transaction);
                    //await _context.SaveChangesAsync();
                    transactionService.UpdateTransaction(transaction);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!transactionService.TransactionExists(transaction.ID))
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
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var transaction = await _context.Transactions
            //    .FirstOrDefaultAsync(m => m.ID == id);
            var transaction = transactionService.GetDetailsById(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var transaction = await _context.Transactions.FindAsync(id);
            //_context.Transactions.Remove(transaction);
            //await _context.SaveChangesAsync();
            transactionService.DeleteTransaction(id);

            return RedirectToAction(nameof(Index));
        }

        //private bool TransactionExists(int id)
        //{
        //    return _context.Transactions.Any(e => e.ID == id);
        //}
    }
}
