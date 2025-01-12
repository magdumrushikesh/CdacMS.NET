using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbFirst.Models;

namespace DbFirst.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ActsJan25Context _context;

        public EmployeesController(ActsJan25Context context)
        {
            _context = context;
            
        }

        //public IActionResult Index()
        //{

        //    return View(employees);
        //}



        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var actsJan25Context = _context.Employees.Include(e => e.DeptNoNavigation);
            return View(await actsJan25Context.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.DeptNoNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptNo", "DeptNo");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpNo,Name,Basic,DeptNo")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(employee);
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync(); //Dataset .Update //Savechange in Entity
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptNo", "DeptNo", employee.DeptNo);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptNo", "DeptNo", employee.DeptNo);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpNo,Name,Basic,DeptNo")] Employee employee)
        {
            if (id != employee.EmpNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee); //first update in dataset
                    await _context.SaveChangesAsync();  //update in db
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpNo))
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
            ViewData["DeptNo"] = new SelectList(_context.Departments, "DeptNo", "DeptNo", employee.DeptNo);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.DeptNoNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmpNo == id);
        }
    }
}
