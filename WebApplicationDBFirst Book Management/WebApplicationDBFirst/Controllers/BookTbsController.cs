using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationDBFirst.Models;

namespace WebApplicationDBFirst.Controllers
{
    public class BookTbsController : Controller
    {
        private readonly PracticeContext _context;

        public BookTbsController(PracticeContext context)
        {
            _context = context;
        }

        // GET: BookTbs
        public async Task<IActionResult> Index()
        {
            var practiceContext = _context.BookTbs.Include(b => b.User);
            return View(await practiceContext.ToListAsync());
        }

        // GET: BookTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTb = await _context.BookTbs
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookTb == null)
            {
                return NotFound();
            }

            return View(bookTb);
        }

        // GET: BookTbs/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.UserTbs, "UserId", "UserId");
            return View();
        }

        // POST: BookTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Bname,Author,Category,Price,UserId")] BookTb bookTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.UserTbs, "UserId", "UserId", bookTb.UserId);
            return View(bookTb);
        }

        // GET: BookTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTb = await _context.BookTbs.FindAsync(id);
            if (bookTb == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.UserTbs, "UserId", "UserId", bookTb.UserId);
            return View(bookTb);
        }

        // POST: BookTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Bname,Author,Category,Price,UserId")] BookTb bookTb)
        {
            if (id != bookTb.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTbExists(bookTb.BookId))
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
            ViewData["UserId"] = new SelectList(_context.UserTbs, "UserId", "UserId", bookTb.UserId);
            return View(bookTb);
        }

        // GET: BookTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTb = await _context.BookTbs
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookTb == null)
            {
                return NotFound();
            }

            return View(bookTb);
        }

        // POST: BookTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookTb = await _context.BookTbs.FindAsync(id);
            if (bookTb != null)
            {
                _context.BookTbs.Remove(bookTb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookTbExists(int id)
        {
            return _context.BookTbs.Any(e => e.BookId == id);
        }
    }
}
