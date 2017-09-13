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
            var applicationDbContext = _context.Mouse.Include(m => m.Line).Include(m => m.PK1).Include(m => m.PK2);
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
                .Include(m => m.Line)
                .Include(m => m.PK1)
                .Include(m => m.PK2)
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
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Description");
            ViewData["PK1ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "FullName");
            ViewData["PK2ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "FullName");
            return View();
        }

        // POST: Mice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MouseID,EarTag,ToeClip,Sex,Birth,Death,LineID,MomID,DadID,PK1ID,PK2ID,SynCre")] Mouse mouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Description", mouse.LineID);
            ViewData["PK1ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "FullName", mouse.PK1ID);
            ViewData["PK2ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "FullName", mouse.PK2ID);
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
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Description", mouse.LineID);
            ViewData["PK1ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "FullName", mouse.PK1ID);
            ViewData["PK2ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "FullName", mouse.PK2ID);
            return View(mouse);
        }

        // POST: Mice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MouseID,EarTag,ToeClip,Sex,Birth,Death,LineID,MomID,DadID,PK1ID,PK2ID,SynCre")] Mouse mouse)
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
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Description", mouse.LineID);
            ViewData["PK1ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "FullName", mouse.PK1ID);
            ViewData["PK2ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "FullName", mouse.PK2ID);
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
                .Include(m => m.Line)
                .Include(m => m.PK1)
                .Include(m => m.PK2)
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
