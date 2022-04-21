using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMS.Data;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class ListOfOnBoardEmpController : Controller
    {
        private readonly EmpDbContext _context;

        public ListOfOnBoardEmpController(EmpDbContext context)
        {
            _context = context;
        }

        // GET: ListOfOnboardEmp
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_listofemp.ToListAsync());
        }

        // GET: ListOfOnboardEmp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfOnboardingEmp = await _context.tbl_listofemp
                .FirstOrDefaultAsync(m => m.ListofEmpID == id);
            if (listOfOnboardingEmp == null)
            {
                return NotFound();
            }

            return View(listOfOnboardingEmp);
        }

        // GET: ListOfOnboardEmp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListOfOnboardEmp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListofEmpID,EmpID,CreatedByID")] ListOfOnboardingEmp listOfOnboardingEmp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfOnboardingEmp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listOfOnboardingEmp);
        }

        // GET: ListOfOnboardEmp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfOnboardingEmp = await _context.tbl_listofemp.FindAsync(id);
            if (listOfOnboardingEmp == null)
            {
                return NotFound();
            }
            return View(listOfOnboardingEmp);
        }

        // POST: ListOfOnboardEmp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListofEmpID,EmpID,CreatedByID")] ListOfOnboardingEmp listOfOnboardingEmp)
        {
            if (id != listOfOnboardingEmp.ListofEmpID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfOnboardingEmp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfOnboardEmpExists(listOfOnboardingEmp.ListofEmpID))
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
            return View(listOfOnboardingEmp);
        }

        // GET: ListOfOnboardEmp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfOnboardingEmp = await _context.tbl_listofemp
                .FirstOrDefaultAsync(m => m.ListofEmpID == id);
            if (listOfOnboardingEmp == null)
            {
                return NotFound();
            }

            return View(listOfOnboardingEmp);
        }

        // POST: ListOfOnboardEmp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfOnboardingEmp = await _context.tbl_listofemp.FindAsync(id);
            _context.tbl_listofemp.Remove(listOfOnboardingEmp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfOnboardEmpExists(int id)
        {
            return _context.tbl_listofemp.Any(e => e.ListofEmpID == id);
        }
    }
}
