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
    public class GenoTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenoTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GenoTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GenoType.ToListAsync());
        }

        // GET: GenoTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genoType = await _context.GenoType
                .SingleOrDefaultAsync(m => m.GenoTypeID == id);
            if (genoType == null)
            {
                return NotFound();
            }

            return View(genoType);
        }

        // GET: GenoTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenoTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenoTypeID,Name,ShortHand")] GenoType genoType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genoType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genoType);
        }

        // GET: GenoTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genoType = await _context.GenoType.SingleOrDefaultAsync(m => m.GenoTypeID == id);
            if (genoType == null)
            {
                return NotFound();
            }
            return View(genoType);
        }

        // POST: GenoTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenoTypeID,Name,ShortHand")] GenoType genoType)
        {
            if (id != genoType.GenoTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genoType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenoTypeExists(genoType.GenoTypeID))
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
            return View(genoType);
        }

        // GET: GenoTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genoType = await _context.GenoType
                .SingleOrDefaultAsync(m => m.GenoTypeID == id);
            if (genoType == null)
            {
                return NotFound();
            }

            return View(genoType);
        }

        // POST: GenoTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genoType = await _context.GenoType.SingleOrDefaultAsync(m => m.GenoTypeID == id);
            _context.GenoType.Remove(genoType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenoTypeExists(int id)
        {
            return _context.GenoType.Any(e => e.GenoTypeID == id);
        }
    }
}
