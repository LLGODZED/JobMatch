using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jobmatch.Data;
using Jobmatch.Models;

namespace Jobmatch.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Job.Include(j => j.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Job.Add(job);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", job.CategoryId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public IActionResult Edit(int? id)
        {
            var job = _context.Job.FirstOrDefault(j => j.Id == id);
            ViewBag.Category = _context.Category.ToList();
            
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            { 
            //_context.Job.Update(Job);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", job.CategoryId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Job.FindAsync(id);
            if (job != null)
            {
                _context.Job.Remove(job);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.Id == id);
        }
        public IActionResult Search()
        {
            var jobs = _context.Job.Include(j => j.Category).ToList();
            return View(jobs);
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var jobs = _context.Job.Include(j => j.Category)
                                   .Where(j => j.Category.Name.Contains(keyword))
                                   .ToList();
            return View("Index", jobs);
        }

        public IActionResult SortAsc()
        {
            var jobs = _context.Job.Include(j => j.Category)
                                   .OrderBy(j => j.Salary)
                                   .ToList();
            return View("Index", jobs);
        }

        public IActionResult SortDesc()
        {
            var jobs = _context.Job.Include(j => j.Category)
                                   .OrderByDescending(j => j.Salary)
                                   .ToList();
            return View("Index", jobs);
        }

    }
}
