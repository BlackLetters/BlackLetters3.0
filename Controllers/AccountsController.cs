using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Services.ImplementationServices;

namespace Biblioteca.Controllers
{
    public class AccountsController : Controller
    {
        //private readonly BibliotecaContext _context;
        private readonly AccountService accountService;

        public AccountsController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Accounts.ToListAsync());
            var account = accountService.GetAllAccounts();

            return View(account);
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var account = await _context.Accounts
            //     .FirstOrDefaultAsync(m => m.ID == id);
            var account = accountService.GetDetailsById(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Password,Username,RoleId,UserRole,CreateAt,UpdateAt")] Account account)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(account);
                //await _context.SaveChangesAsync();
                accountService.Create(account);

                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var account = await _context.Accounts.FindAsync(id);
            var account = accountService.GetDetailsById(id);

            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Password,Username,RoleId,UserRole,CreateAt,UpdateAt")] Account account)
        {
            if (id != account.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(account);
                    //wait _context.SaveChangesAsync();
                    accountService.UpdateAccount(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!accountService.AccountExists(account.ID))
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
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var account = await _context.Accounts
            //    .FirstOrDefaultAsync(m => m.ID == id);
            var account = accountService.GetDetailsById(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var account = await _context.Accounts.FindAsync(id);
            //_context.Accounts.Remove(account);
            //await _context.SaveChangesAsync();
            accountService.DeleteAccount(id);

            return RedirectToAction(nameof(Index));
        }

        //private bool AccountExists(int id)
        //{
        //    return _context.Accounts.Any(e => e.ID == id);
        //}
    }
}
