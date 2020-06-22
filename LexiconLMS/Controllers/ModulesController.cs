using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LexiconLMS.Data;
using LexiconLMS.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using LexiconLMS.Models.ViewModel;

namespace LexiconLMS.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public ModulesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Modules
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Modules.Include(m => m.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Modules/Details/5
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var module = await mapper
                .ProjectTo<ModuleDetailViewModel>(_context.Modules
                .Include(m => m.Course)
                .Include(t => t.Tasks))
                .FirstOrDefaultAsync(e => e.Id == id);

            if (module == null)
            {
                return NotFound();
            }

            return View(module);
        }

        // GET: Modules/Create
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Name");
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartDate,EndDate,CourseId")] Module module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(module);
                await _context.SaveChangesAsync();
                return Redirect("/Courses/Details/" + module.CourseId);
            }
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Name");
            return View(module);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CourseCreate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var courses = await _context.Courses.FindAsync(id);
            ViewData["coursename"] = courses.Name;
            ViewData["courseid"] = courses.Id;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CourseCreate([Bind("Name,Description,StartDate,EndDate,CourseId")] Module module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(module);
                await _context.SaveChangesAsync();
                return Redirect("/Courses/Details/" + module.CourseId);
            }
            return View(module);
        }


        // GET: Modules/Edit/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await mapper
                .ProjectTo<ModuleEditViewModel>(_context.Modules
                .Include(m => m.Course)
                .Include(t => t.Tasks))
                .FirstOrDefaultAsync(e => e.Id == id);
            if (module == null)
            {
                return NotFound();
            }
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Name");

            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartDate,EndDate")] Module module)
        {
            var model = await mapper
                .ProjectTo<ModuleEditViewModel>(_context.Modules
                .Include(m => m.Course)
                .Include(t => t.Tasks))
                .FirstOrDefaultAsync(e => e.Id == id);

            module.CourseId = model.CourseId;

            if (id != module.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(module.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Modules/Details/" + id);
            }
            ViewData["Courses"] = new SelectList(_context.Courses, "Id", "Name");
            return View(model);
        }

        // GET: Modules/Delete/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var module = await _context.Modules
                .Include(m => m.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (module == null)
            {
                return NotFound();
            }

            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
            return Redirect("/Courses/Details/" + module.CourseId);
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.Id == id);
        }
    }
}
