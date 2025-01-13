using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationDBFirst.Models;
using Microsoft.AspNetCore.Http; // For Session Extensions

namespace WebApplicationDBFirst.Controllers
{
    public class UserTbsController : Controller
    {
        private readonly PracticeContext _context;

        public UserTbsController(PracticeContext context)
        {
            _context = context;
        }

        // GET: UserTbs
        public async Task<IActionResult> Index()
        {

            return View(await _context.UserTbs.ToListAsync());
        }

        // GET: UserTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTb = await _context.UserTbs
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userTb == null)
            {
                return NotFound();
            }

            return View(userTb);
        }

        // GET: UserTbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Email,MobileNo,Password,Role")] UserTb userTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTb);
        }


        public IActionResult Login()
        {
            return View();
        }

        // POST: UserTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] UserTb userTb)
        {
            var user = await _context.UserTbs.FirstOrDefaultAsync(user => user.Username == userTb.Username);

            if (user != null && user.Password == userTb.Password) {

                HttpContext.Session.SetInt32("userId", user.UserId);
                HttpContext.Session.SetString("userName", user.Username);
           
                if (user.Role.Equals("Admin")){ 
                    return RedirectToAction("Index");
                }
                else {
                    return RedirectToAction("Index", "BookTbs");
                }

            }
            return View();

        }

        // GET: UserTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTb = await _context.UserTbs.FindAsync(id);
            if (userTb == null)
            {
                return NotFound();
            }
            return View(userTb);
        }

        // POST: UserTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Email,MobileNo,Password,Role")] UserTb userTb)
        {
            if (id != userTb.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTbExists(userTb.UserId))
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
            return View(userTb);
        }

        // GET: UserTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTb = await _context.UserTbs
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userTb == null)
            {
                return NotFound();
            }

            return View(userTb);
        }

        // POST: UserTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTb = await _context.UserTbs.FindAsync(id);
            if (userTb != null)
            {
                _context.UserTbs.Remove(userTb);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTbExists(int id)
        {
            return _context.UserTbs.Any(e => e.UserId == id);
        }
    }
}
