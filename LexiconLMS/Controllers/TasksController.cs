using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LexiconLMS.Data;
using LexiconLMS.Models;
using AutoMapper;
using LexiconLMS.Models.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

namespace LexiconLMS.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public TasksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Tasks
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> Index()
        {
            //var lexiconLMSContext = _context.Tasks.Include(t => t.Module).Include(t => t.TaskType);
            //return View(await lexiconLMSContext.ToListAsync());

            var model = await mapper.ProjectTo<TaskListViewModel>(_context.Tasks).ToListAsync();
            return View(model);
        }

        // GET: Tasks/Details/5
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await mapper.ProjectTo<TaskDetailsViewModel>(_context.Tasks).FirstOrDefaultAsync(t => t.Id == id);
            //var task = await _context.Tasks
            //    .Include(t => t.Module)
            //    .Include(t => t.TaskType)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            
            //ViewData["ModuleId"] = new SelectList(_context.Set<Module>(), "Id", "Name");
            //ViewData["TaskTypeId"] = new SelectList(_context.Set<TaskType>(), "Id", "Name");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(/*[Bind("Id,Name,StartDate,EndDate,ModuleId,TaskTypeId")]*/ TaskCreateViewModel task)
        {
            var modules = await _context.Modules.FindAsync(task.ModuleId);
            CheckDate(task.StartDate, task.EndDate, modules.StartDate, modules.EndDate);

            if (ModelState.IsValid)
            {
                var newtask = mapper.Map<Models.Task>(task);
                _context.Add(newtask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ModuleId"] = new SelectList(_context.Set<Module>(), "Id", "Name", task.ModuleId);
            //ViewData["TaskTypeId"] = new SelectList(_context.Set<TaskType>(), "Id", "Name", task.TaskTypeId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var task = await _context.Tasks.FindAsync(id);
            var task = await mapper.ProjectTo<TaskEditViewModel>(_context.Tasks).FirstOrDefaultAsync(e=> e.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            var module = await _context.Modules.FirstOrDefaultAsync(m => m.Id == id);
            ViewData["moduleStartDate"] = module.StartDate;
            ViewData["moduleEndDate"] = module.EndDate;
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartDate,EndDate,ModuleId,TaskTypeId")] Models.Task task)
        {
            var model = await mapper.ProjectTo<TaskEditViewModel>(_context.Tasks).FirstOrDefaultAsync(e => e.Id == id);
            if (id != task.Id)
            {
                return NotFound();
            }

            var modules = await _context.Modules.FindAsync(task.ModuleId);
            CheckDate(task.StartDate, task.EndDate, modules.StartDate, modules.EndDate);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return Redirect("~/Modules/Details/" + task.ModuleId);
            }
            ViewData["moduleStartDate"] = modules.StartDate;
            ViewData["moduleEndDate"] = modules.EndDate;
            return View(model);
        }

        // GET: Tasks/Delete/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await mapper.ProjectTo<TaskDeleteViewModel>(_context.Tasks).FirstOrDefaultAsync(t => t.Id == id);
            //var task = await _context.Tasks
            //    .Include(t => t.Module)
            //    .Include(t => t.TaskType)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await mapper.ProjectTo<TaskDeleteViewModel>(_context.Tasks).FirstOrDefaultAsync(t => t.Id == id);
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Redirect("~/Modules/Details/" + task.ModuleId);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> ModuleCreate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var modules = await _context.Modules.FindAsync(id);
            ViewData["modulename"] = modules.Name;
            ViewData["moduleid"] = modules.Id;
            ViewData["moduleStartDate"] = modules.StartDate;
            ViewData["moduleEndDate"] = modules.EndDate;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> ModuleCreate([Bind("Name,StartDate,EndDate,ModuleId,TaskTypeId")] Models.Task task)
        {
            var model = await mapper.ProjectTo<TaskCreateViewModel>(_context.Tasks).FirstOrDefaultAsync(t => t.Id == task.Id);
            var modules = await _context.Modules.FindAsync(task.ModuleId);

            CheckDate(task.StartDate, task.EndDate, modules.StartDate, modules.EndDate);

            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return Redirect("~/Modules/Details/" + task.ModuleId);
            }
            ViewData["modulename"] = modules.Name;
            ViewData["moduleid"] = modules.Id;
            ViewData["moduleStartDate"] = modules.StartDate;
            ViewData["moduleEndSate"] = modules.EndDate;
            
            return View(model);
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

        private bool ModuleNotEmpty()
        {
            return (!_context.Modules.Any());
        }

        private void CheckDate(DateTime taskStart, DateTime taskEnd, DateTime moduleStart, DateTime moduleEnd)
        {
            if (moduleStart > taskStart)
            {
                ModelState.AddModelError("StartDate", $"Starttid för aktiviteten kan inte vara tidigare än starttid för modulen - {moduleStart:yyyy-MM-dd hh:mm}");
            }
            if (moduleEnd < taskEnd)
            {
                ModelState.AddModelError("EndDate", $"Sluttid för aktiviteten kan inte vara senare än sluttid för modulen - {moduleEnd:yyyy-MM-dd hh:mm}");
            }
            if (taskStart > taskEnd)
            {
                ModelState.AddModelError("EndDate", "Aktiviteten kan inte ha en tidigare slutttid än starttid");
            }
        }
    }
}