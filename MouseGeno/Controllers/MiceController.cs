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
    public class MiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mice
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mouse.Include(m => m.GenoType).Include(m => m.Line);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouse = await _context.Mouse
                .Include(m => m.GenoType)
                .Include(m => m.Line)
                .SingleOrDefaultAsync(m => m.MouseID == id);
            if (mouse == null)
            {
                return NotFound();
            }

            return View(mouse);
        }

        // GET: Mice/Create
        public IActionResult Create()
        {
            ViewData["GenoTypeID"] = new SelectList(_context.GenoType, "GenoTypeID", "Name");
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Description");
            return View();
        }

        // POST: Mice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MouseID,EarTag,ToeClip,Sex,Birth,Death,GenoTypeID,LineID,MomID,DadID")] Mouse mouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenoTypeID"] = new SelectList(_context.GenoType, "GenoTypeID", "Name", mouse.GenoTypeID);
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Description", mouse.LineID);
            return View(mouse);
        }

        // GET: Mice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouse = await _context.Mouse.SingleOrDefaultAsync(m => m.MouseID == id);
            if (mouse == null)
            {
                return NotFound();
            }
            ViewData["GenoTypeID"] = new SelectList(_context.GenoType, "GenoTypeID", "Name", mouse.GenoTypeID);
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Description", mouse.LineID);
            return View(mouse);
        }

        // POST: Mice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MouseID,EarTag,ToeClip,Sex,Birth,Death,GenoTypeID,LineID,MomID,DadID")] Mouse mouse)
        {
            if (id != mouse.MouseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MouseExists(mouse.MouseID))
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
            ViewData["GenoTypeID"] = new SelectList(_context.GenoType, "GenoTypeID", "Name", mouse.GenoTypeID);
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Description", mouse.LineID);
            return View(mouse);
        }

        // GET: Mice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouse = await _context.Mouse
                .Include(m => m.GenoType)
                .Include(m => m.Line)
                .SingleOrDefaultAsync(m => m.MouseID == id);
            if (mouse == null)
            {
                return NotFound();
            }

            return View(mouse);
        }

        // POST: Mice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mouse = await _context.Mouse.SingleOrDefaultAsync(m => m.MouseID == id);
            _context.Mouse.Remove(mouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MouseExists(int id)
        {
            return _context.Mouse.Any(e => e.MouseID == id);
        }
    }
}
