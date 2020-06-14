 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LexiconLMS.Data;
using LexiconLMS.Models;
using LexiconLMS.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LexiconLMS.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LexiconLMS.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }


        // GET: Courses/Details/5

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(c => c.Course) //theninclude för att traversera activities osv
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
                          

            var userView = await _mapper.ProjectTo<UserViewModel>(_context.Users)
                .FirstOrDefaultAsync(u => u.Id == id);
            var userToUpdate = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(userToUpdate);
            userView.Role = roles[0];

            if (userView == null)
            {
                return NotFound();
            }

            ViewData["Role"] = new SelectList(_roleManager.Roles, "Name", "Name");
            
            CourseDropDownList();

            return View(userView);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Role,CourseId")] UserViewModel user)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            //get user form DB with Id
            var userToUpdate = await _userManager.FindByIdAsync(id);
            //copy properties from UserViewModel to user
            PropertyCopier.CopyTo(user, userToUpdate);
            //remove old roll and add the new one 
            var roles = await _userManager.GetRolesAsync(userToUpdate);
            await _userManager.RemoveFromRoleAsync(userToUpdate,roles[0]);
            var addToRoleResult = await _userManager.AddToRoleAsync(userToUpdate, user.Role);
            //check if the role is added or not 
            if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userToUpdate);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (UserExists(userToUpdate.Id))
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

            CourseDropDownList(user.CourseId);
            //RoleDropDownList(user.Role);
            ViewData["Role"] = new SelectList(_roleManager.Roles, "Name", "Name", roles[0]);
            return View(user);
        }


        // GET: users/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            

            return View(user);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        
        private void CourseDropDownList(object selectedCourse = null)
        {
            var courseQuery = from d in _context.Courses
                              orderby d.Name
                              select d;
            ViewBag.courseId = new SelectList(courseQuery.AsNoTracking(), "Id", "Name", selectedCourse);
        }
        private void RoleDropDownList(object selectedrole = null)
        {

            var roleQuery = _roleManager.Roles;
                              
            ViewBag.Role = new SelectList(roleQuery.AsNoTracking(), "Id", "Name", selectedrole);
        }
    }
}