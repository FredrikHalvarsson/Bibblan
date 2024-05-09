using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bibblan.Data;
using Bibblan.Models;

namespace Bibblan.Controllers
{
    public class BookCheckoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookCheckoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookCheckouts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookCheckouts.Include(b => b.Book).Include(b => b.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookCheckouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCheckout = await _context.BookCheckouts
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookCheckoutId == id);
            if (bookCheckout == null)
            {
                return NotFound();
            }

            return View(bookCheckout);
        }

        // GET: BookCheckouts/Create
        public IActionResult Create()
        {
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookName");
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: BookCheckouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookCheckoutId,FkCustomerId,FkBookId,DateCreated,IsReturned,DueDate")] BookCheckout bookCheckout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCheckout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookCheckout.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", bookCheckout.FkCustomerId);
            return View(bookCheckout);
        }

        // GET: BookCheckouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCheckout = await _context.BookCheckouts.FindAsync(id);
            if (bookCheckout == null)
            {
                return NotFound();
            }
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookCheckout.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", bookCheckout.FkCustomerId);
            return View(bookCheckout);
        }

        // POST: BookCheckouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookCheckoutId,FkCustomerId,FkBookId,DateCreated,IsReturned,DueDate")] BookCheckout bookCheckout)
        {
            if (id != bookCheckout.BookCheckoutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCheckout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCheckoutExists(bookCheckout.BookCheckoutId))
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
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookCheckout.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerEmail", bookCheckout.FkCustomerId);
            return View(bookCheckout);
        }

        // GET: BookCheckouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCheckout = await _context.BookCheckouts
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookCheckoutId == id);
            if (bookCheckout == null)
            {
                return NotFound();
            }

            return View(bookCheckout);
        }

        // POST: BookCheckouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCheckout = await _context.BookCheckouts.FindAsync(id);
            if (bookCheckout != null)
            {
                _context.BookCheckouts.Remove(bookCheckout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCheckoutExists(int id)
        {
            return _context.BookCheckouts.Any(e => e.BookCheckoutId == id);
        }
    }
}
