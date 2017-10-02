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
using static MouseGeno.Models.ViewModels.CageLineViewModel;

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
        public IActionResult Index(int lineID)
        {
            List<Cage> cagesInLine = (
                from c in _context.Cage
                join mc in _context.MouseCage on c.CageID equals mc.CageID
                join m in _context.Mouse on mc.MouseID equals m.MouseID
                where mc.EndDate == null
                && m.LineID == lineID
                select c).ToList();


            List<Mouse> miceInLine = _context.Mouse.Where(m => m.LineID == lineID && m.Death == null).Include(m => m.MouseCages).ToList();
            Line line = _context.Line.Single(x => x.LineID == lineID);
            List<CagedMice> cagedMice = new List<CagedMice>();
            
            foreach(Cage cage in cagesInLine)
            {
                ICollection<MouseCage> mouseCages = _context.MouseCage.Where(mc => mc.EndDate == null).ToList();
                List<Mouse> mice = (
                    from m in miceInLine
                    from mc in mouseCages
                    where m.MouseID == mc.MouseID
                    && mc.CageID == cage.CageID
                    select m).ToList();

                cagedMice.Add(
                    new CagedMice
                    {
                        Cage = cage,
                        Mice = mice
      
                    }
                );
            }
            CageLineViewModel model = new CageLineViewModel
            {
                Line = line,
                MiceInCages = cagedMice
            };

            return View(model);
        }

        // GET: Cages/Details/5
        public async Task<IActionResult> Details(int id)
        {

            Cage cage = await _context.Cage
                .SingleOrDefaultAsync(m => m.CageID == id);

            if (cage == null)
            {
                return NotFound();
            }

            List<Mouse> miceInCage = (
                from m in _context.Mouse
                from mc in _context.MouseCage
                where m.MouseID == mc.MouseID
                && mc.EndDate == null
                && mc.CageID == id
                select m).Include(m => m.PK1).Include(m => m.PK2).Include(m => m.Line).ToList();


            foreach(Mouse mouse in miceInCage )
            {
                List<MouseTask> mouseTasks = _context.MouseTask.Where(mt => mt.MouseID == mouse.MouseID).OrderBy(mt => mt.Date).ToList();
                if(mouseTasks.Count() !=0)
                {
                    mouse.MouseTasks = mouseTasks;
                }
                if(mouse.DadID != null)
                {
                    mouse.Dad = _context.Mouse.Single(m => m.MouseID == mouse.DadID);
                }
                if (mouse.MomID != null)
                {
                    mouse.Mom = _context.Mouse.Single(m => m.MouseID == mouse.MomID);
                }
            }

            List<TaskType> actions = _context.TaskType.ToList();

            List<Condition> changes = _context.Condition.ToList();

            CageDetailsViewModel model = new CageDetailsViewModel
            {
                Cage = cage,
                MiceInCage = miceInCage,
                Actions = actions,
                Changes = changes
            };

            return View(model);
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
            if(mouse.PK1ID != null)
            {
                mouse.PK1 = _context.GeneExpression.Single(g => g.GeneExpressionID == mouse.PK1ID);
            }
            if (mouse.PK2ID != null)
            {
                mouse.PK2 = _context.GeneExpression.Single(g => g.GeneExpressionID == mouse.PK2ID);
            }
            if(mouse.MomID != null)
            {
                mouse.Mom = _context.Mouse.Single(m => m.MouseID == mouse.MomID);
            }
            if (mouse.DadID != null)
            {
                mouse.Dad = _context.Mouse.Single(m => m.MouseID == mouse.DadID);
            }

            Cage currentCage = _context.Cage.SingleOrDefault(c => c.CageID == _context.MouseCage.SingleOrDefault(mc => mc.MouseID == mouseID && mc.EndDate == null).CageID);

            List<Cage> usedStandardCages = (
                from c in _context.Cage
                join mc in _context.MouseCage on c.CageID equals mc.CageID
                where c.Breeding == false
                && mc.EndDate == null
                select c 
                ).Distinct().ToList();

            List<Cage> usedStandardInLine = (
                from c in usedStandardCages
                join mc in _context.MouseCage on c.CageID equals mc.CageID
                join m in _context.Mouse on mc.MouseID equals m.MouseID
                where mc.EndDate == null
                && c.Breeding == false
                && m.LineID == mouse.LineID
                select c).Distinct().ToList();

            List<Cage> usedBreederCages = (
                from c in _context.Cage
                from mc in _context.MouseCage
                where c.Breeding == true
                && c.CageID == mc.CageID
                && mc.EndDate == null
                select c
                ).Distinct().ToList();

            List<Cage> usedBreedingInLine = (
                from c in usedStandardCages
                join mc in _context.MouseCage on c.CageID equals mc.CageID
                join m in _context.Mouse on mc.MouseID equals m.MouseID
                where mc.EndDate == null
                && c.Breeding == true
                && m.LineID == mouse.LineID
                select c).Distinct().ToList();


            List<Cage> allBreederCages = _context.Cage.Where(c => c.Breeding == true).ToList();
            List<Cage> allStandardCages = _context.Cage.Where(c => c.Breeding == false).ToList();
            List<Cage> notUsedBreederCages = allBreederCages.Except(usedBreederCages).ToList();
            List<Cage> notUsedStandardCages = allStandardCages.Except(usedStandardCages).ToList();


            CageAssignViewModel model = new CageAssignViewModel
            {
                Mouse = mouse,
                UsedBreederCages = usedBreederCages,
                UsedStandardCages = usedStandardCages,
                NotUsedBreederCages = notUsedBreederCages,
                NotUsedStandardCages = notUsedStandardCages,
                CurrentCage = currentCage
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult ExecuteCageAssign (CageAssignViewModel model)
        {
            Mouse mouse = _context.Mouse.Single(m => m.MouseID == model.MouseID);
            mouse.MouseCages = _context.MouseCage.Where(mc => mc.MouseID == mouse.MouseID).ToList();

            if(mouse.MouseCages != null)
            {
                if (mouse.MouseCages.Any(mc => mc.EndDate == null))
                {
                    Cage currentCage = _context.Cage.SingleOrDefault(c => c.CageID == _context.MouseCage.Single(mc => mc.EndDate == null && mc.MouseID == mouse.MouseID).CageID);
                    if(currentCage != null)
                    {
                        MouseCage oldMouseCage = _context.MouseCage.Single(mc => mc.MouseID == model.MouseID && mc.CageID == currentCage.CageID && mc.EndDate == null);
                        oldMouseCage.EndDate = model.Date;
                        _context.MouseCage.Update(oldMouseCage);
                        _context.SaveChanges();
                    }

                }
            }
           _context.MouseCage.Add(
                new MouseCage
                {
                    CageID = model.NewCageID,
                    MouseID = model.MouseID,
                    StartDate = model.Date
                }
                );
            _context.SaveChanges();

            return RedirectToAction("Details", "Lines", new { id = mouse.LineID});

        }
    }
}

