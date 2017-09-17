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
using Microsoft.AspNetCore.Identity;

namespace MouseGeno.Controllers
{
    public class TaskTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskTypesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: TaskTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskType.ToListAsync());
        }

        // GET: TaskTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskType = await _context.TaskType
                .SingleOrDefaultAsync(m => m.TaskTypeID == id);
            if (taskType == null)
            {
                return NotFound();
            }

            return View(taskType);
        }

        // GET: TaskTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskTypeID,Name,Instructions,MeasurementType")] TaskType taskType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskType);
        }

        // GET: TaskTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskType = await _context.TaskType.SingleOrDefaultAsync(m => m.TaskTypeID == id);
            if (taskType == null)
            {
                return NotFound();
            }
            return View(taskType);
        }

        // POST: TaskTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskTypeID,Name,Instructions,MeasurementType")] TaskType taskType)
        {
            if (id != taskType.TaskTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskTypeExists(taskType.TaskTypeID))
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
            return View(taskType);
        }

        // GET: TaskTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskType = await _context.TaskType
                .SingleOrDefaultAsync(m => m.TaskTypeID == id);
            if (taskType == null)
            {
                return NotFound();
            }

            return View(taskType);
        }

        // POST: TaskTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskType = await _context.TaskType.SingleOrDefaultAsync(m => m.TaskTypeID == id);
            _context.TaskType.Remove(taskType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskTypeExists(int id)
        {
            return _context.TaskType.Any(e => e.TaskTypeID == id);
        }

        public IActionResult TaskOnCage (int cageID, int taskID)
        {

            Cage cage = _context.Cage.Single(c => c.CageID == cageID);

            List<Mouse> miceInCage = (
                from m in _context.Mouse
                from mc in _context.MouseCage
                where m.MouseID == mc.MouseID
                && mc.EndDate == null
                && mc.CageID == cageID
                select m).Include(m => m.PK1).Include(m => m.PK2).Include(m => m.Line).ToList();

            foreach (Mouse mouse in miceInCage)
            {
                if (mouse.DadID != null)
                {
                    mouse.Dad = _context.Mouse.Single(m => m.MouseID == mouse.DadID);
                }
                if (mouse.MomID != null)
                {
                    mouse.Mom = _context.Mouse.Single(m => m.MouseID == mouse.MomID);
                }
            }


            TaskOnCageViewModel model = new TaskOnCageViewModel
            {
                MiceInCage = miceInCage,
                TaskType = _context.TaskType.Single(t => t.TaskTypeID == taskID),
                Cage = cage

            };


            return View(model);
        }

        public async Task<IActionResult> PerformTaskOnCage (List<Mouse> mice, List<MouseTask> mouseTasks, DateTime date, int cageID, int taskTypeID)
        {
            ApplicationUser user = await GetCurrentUserAsync();

            foreach (MouseTask mt in mouseTasks)
            {
                if(mt.Data != null)
                {
                    _context.MouseTask.Add(
                        new MouseTask
                        {
                            MouseID = mt.MouseID,
                            TaskTypeID = mt.TaskTypeID,
                            Date = date,
                            Data = mt.Data,
                            User = user,
                            Comments = mt.Comments
                    }
                    );
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Cages", new { id = cageID });
        }
    }
}
