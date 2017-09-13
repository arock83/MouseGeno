using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MouseGeno.Data;
using MouseGeno.Models;

namespace MouseGeno.Controllers
{
    public class HealthStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HealthStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HealthStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.HealthStatus.ToListAsync());
        }

        // GET: HealthStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthStatus = await _context.HealthStatus
                .SingleOrDefaultAsync(m => m.HealthStatusID == id);
            if (healthStatus == null)
            {
                return NotFound();
            }

            return View(healthStatus);
        }

        // GET: HealthStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HealthStatusID,Name,Description")] HealthStatus healthStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthStatus);
        }

        // GET: HealthStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthStatus = await _context.HealthStatus.SingleOrDefaultAsync(m => m.HealthStatusID == id);
            if (healthStatus == null)
            {
                return NotFound();
            }
            return View(healthStatus);
        }

        // POST: HealthStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HealthStatusID,Name,Description")] HealthStatus healthStatus)
        {
            if (id != healthStatus.HealthStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthStatusExists(healthStatus.HealthStatusID))
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
            return View(healthStatus);
        }

        // GET: HealthStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthStatus = await _context.HealthStatus
                .SingleOrDefaultAsync(m => m.HealthStatusID == id);
            if (healthStatus == null)
            {
                return NotFound();
            }

            return View(healthStatus);
        }

        // POST: HealthStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthStatus = await _context.HealthStatus.SingleOrDefaultAsync(m => m.HealthStatusID == id);
            _context.HealthStatus.Remove(healthStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthStatusExists(int id)
        {
            return _context.HealthStatus.Any(e => e.HealthStatusID == id);
        }
    }
}
