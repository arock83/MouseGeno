using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MouseGeno.Data;
using MouseGeno.Models;
using MouseGeno.Models.ViewModels;

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
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Name");
            ViewData["PK1ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "ShortHand");
            ViewData["PK2ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "ShortHand");
            return View();
        }

        // POST: Mice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mouse mouse)
        {
            if (ModelState.IsValid)
            {
                mouse.PK1 = await _context.GeneExpression.SingleAsync(g => g.GeneExpressionID == mouse.PK1ID);
                mouse.PK2 = await _context.GeneExpression.SingleAsync(g => g.GeneExpressionID == mouse.PK2ID);
                _context.Add(mouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineID"] = new SelectList(_context.Line, "LineID", "Name", mouse.LineID);
            ViewData["PK1ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "ShortHand", mouse.PK1ID);
            ViewData["PK2ID"] = new SelectList(_context.GeneExpression, "GeneExpressionID", "ShortHand", mouse.PK2ID);
            return RedirectToRoute("Line", "Index");
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
                    mouse.PK1 = await _context.GeneExpression.SingleAsync(g => g.GeneExpressionID == mouse.PK1ID);
                    mouse.PK2 = await _context.GeneExpression.SingleAsync(g => g.GeneExpressionID == mouse.PK2ID);
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

        //Make Litter
        [HttpGet]
        public IActionResult NewLitter(int cageID, int numOfPups)
        {

            Cage cage = _context.Cage.Single(c => c.CageID == cageID);
            List<Mouse> parents = (
                from m in _context.Mouse
                from mc in _context.MouseCage
                where m.MouseID == mc.MouseID
                && mc.EndDate == null
                && mc.CageID == cage.CageID
                select m).Include(m => m.PK1).Include(m => m.PK2).Include(m => m.Line).ToList();
            if(parents.Where(m => m.Sex == "F").Count() == 0 || parents.Where(m => m.Sex == "M").Count() == 0)
            {
                return RedirectToAction("Details", "Cages", new { id = cage.CageID });
            }
            List<Mouse> pups = new List<Mouse>();
            for(int n = 0; n < numOfPups; n++)
            {
                pups.Add(new Mouse() );
            }

            NewLitterViewModel model = new NewLitterViewModel();
            model.Cage = cage;
            model.Parents = parents;
            model.NumOfPups = numOfPups;
            model.Pups = pups;
            
            return View(model);
        }
        [HttpPost]
        public IActionResult NewLitter(NewLitterViewModel model)
        {


            for(int n = 0; n < model.Pups.Count(); n++)
            {
                _context.Mouse.Add(
                    new Mouse
                    {
                        ToeClip = model.Pups[n].ToeClip,
                        MomID = model.MomID,
                        DadID = model.DadID,
                        Sex = model.Pups[n].Sex,
                        Birth = model.BirthDate,
                        LineID = _context.Line.Single(l => l.LineID == _context.Mouse.Single(m => m.MouseID == model.MomID).LineID).LineID
                    }
                    );
                _context.SaveChanges();
                Mouse newPup = _context.Mouse.Single(m => m.ToeClip == model.Pups[n].ToeClip && m.Sex == model.Pups[n].Sex && m.Birth == model.BirthDate);
                _context.MouseCage.Add(
                    new MouseCage
                    {
                        
                        MouseID = newPup.MouseID,
                        CageID = model.CageID,
                        StartDate = model.BirthDate
                    }
                    );
                
                 _context.SaveChanges();
            }


            _context.SaveChanges();

            return RedirectToAction("Details", "Cages", new { id = model.CageID });
        }
    }
}
