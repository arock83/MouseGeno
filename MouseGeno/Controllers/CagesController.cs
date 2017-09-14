﻿using System;
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
    public class CagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cage.ToListAsync());
        }

        // GET: Cages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cage = await _context.Cage
                .SingleOrDefaultAsync(m => m.CageID == id);
            if (cage == null)
            {
                return NotFound();
            }

            return View(cage);
        }

        // GET: Cages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CageID,CageNumber,Cubicle,Breeding")] Cage cage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cage);
        }

        // GET: Cages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cage = await _context.Cage.SingleOrDefaultAsync(m => m.CageID == id);
            if (cage == null)
            {
                return NotFound();
            }
            return View(cage);
        }

        // POST: Cages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CageID,CageNumber,Cubicle,Breeding")] Cage cage)
        {
            if (id != cage.CageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CageExists(cage.CageID))
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
            return View(cage);
        }

        // GET: Cages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cage = await _context.Cage
                .SingleOrDefaultAsync(m => m.CageID == id);
            if (cage == null)
            {
                return NotFound();
            }

            return View(cage);
        }

        // POST: Cages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cage = await _context.Cage.SingleOrDefaultAsync(m => m.CageID == id);
            _context.Cage.Remove(cage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CageExists(int id)
        {
            return _context.Cage.Any(e => e.CageID == id);
        }

        //Add Mouse to a Cage
        [HttpGet]
        public IActionResult CageAssign(int mouseID)
        {
            Mouse mouse = _context.Mouse.Single(m => m.MouseID == mouseID);
            List<Cage> allCages = _context.Cage.ToList();
            List<MouseCage> allMouseCage = _context.MouseCage.ToList();
            List<Cage> allBreederCages = allCages.Where(c => c.Breeding == true).ToList();
            List<Cage> allStandardCages = allCages.Where(c => c.Breeding == false).ToList();
            List<Cage> usedBreederCages = (
                    from c in allBreederCages
                    from mc in allMouseCage
                    where mc.EndDate == null
                    && c.CageID == mc.CageID
                    select c).ToList();
            List<Cage> notUsedBreederCages = allBreederCages.Except(usedBreederCages).ToList();
            List<Cage> usedStandardCages = (
                    from c in allStandardCages
                    join mc in allMouseCage on c.CageID equals mc.CageID
                    where mc.EndDate != null
                    select c).ToList();
            List<Cage> notUsedStandardCages = allStandardCages.Except(usedStandardCages).ToList();
            CageAssignViewModel model = new CageAssignViewModel
            {
                Mouse = mouse,
                UsedBreederCages = usedBreederCages,
                UsedStandardCages = usedStandardCages,
                NotUsedBreederCages = notUsedBreederCages,

                NotUsedStandardCages = notUsedStandardCages
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CageAssign (CageAssignViewModel model)
        {
            Mouse mouse = _context.Mouse.Single(m => m.MouseID == model.mouseID);
           _context.MouseCage.Add(
                new MouseCage
                {
                    CageID = model.cageID,
                    MouseID = model.mouseID,
                    StartDate = model.date
                }
                );
            _context.SaveChanges();

            return RedirectToAction("Details", "Lines", new { id = mouse.LineID});

        }
    }
}
