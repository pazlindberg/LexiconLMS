﻿ using System;
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
using System.Runtime.CompilerServices;
using LexiconLMS.Areas.Identity.Pages.Account;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Schema;

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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, ILogger<RegisterModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _logger = logger;

        }


        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .Include(u => u.Course)
                .OrderBy(u => u.Email).ToListAsync();
            
            return View(users);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Filter(string searchInput)
        {
            //retrive users from database
            var users = _context.Users
                .Include(u => u.Course)
                .OrderBy(u => u.Email).AsQueryable();

            var filterList = new List<User>();

            if (!string.IsNullOrEmpty(searchInput))
            {
                if ("lärare".Contains(searchInput.ToLower()))
                {
                    var listUser = await users.ToListAsync();
                    var teacherUser = listUser.Except(await _userManager.GetUsersInRoleAsync("Student")).ToList();
                    filterList.AddRange(teacherUser);
                    
                }
                if("student".Contains(searchInput.ToLower()))
                {
                    var listUser = await users.ToListAsync();
                    var studentUser = listUser.Except(await _userManager.GetUsersInRoleAsync("Teacher")).ToList();
                    filterList.AddRange(studentUser);
                }

                   var otherFilterlist = string.IsNullOrWhiteSpace(searchInput) ?
                           users :
                           users
                           .Where(u => u.Email.ToLower().Contains(searchInput.ToLower())
                                    || u.Course.Name.ToLower().Contains(searchInput.ToLower())
                                    || u.FirstName.ToLower().Contains(searchInput.ToLower())
                                    || u.LastName.ToLower().Contains(searchInput.ToLower())
                                    );
                     

                    filterList.AddRange(await otherFilterlist.ToListAsync());
                    return View(nameof(Index), filterList.Distinct().ToList());

            }
            return View(nameof(Index), await users.ToListAsync());

        }





        public async Task<IActionResult> MyPage(string id)
        {
            var users = _context.Users
                        .Include(u => u.Course)
                            .ThenInclude(c => c.Modules)
                                .ThenInclude(m => m.Tasks)
                        .Include(u => u.Course)
                            .ThenInclude(c => c.Users);

            var userView = await _mapper.ProjectTo<UserViewModel>(users)
                            .FirstOrDefaultAsync(u => u.Id == id);
            return View(userView);

        }
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(int Id)
        {
            ViewBag.courseId = Id;
            var course =  _context.Courses.FirstOrDefault(c => c.Id == Id);
            ViewBag.courseName = course.Name;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(int Id, /*[Bind("FirstName,LastName,Email")] */UserViewModel user)
        {
            if (ModelState.IsValid)
            {

                var resultFound = await _userManager.FindByEmailAsync(user.Email);
                if (resultFound ==null)
                {
                    var newUser = new User { FirstName = user.FirstName, LastName = user.LastName, UserName = user.Email, Email = user.Email };
                    var result = await _userManager.CreateAsync(newUser, "a123");
                    newUser.CourseId = Id;
                    var addToRoleResult = await _userManager.AddToRoleAsync(newUser,"Student");
                    if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        return LocalRedirect("~/User/Create/"+Id);
                        
                    }
                    

                }
                else
                {
                    ModelState.AddModelError("Email", "E-postadressen redan knuten till befintlig användare");
                    return View();

                }
            }
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id==Id);
            ViewBag.courseName = course.Name;
            ViewBag.courseId = Id;
            


            return View(user);
        }

        // GET: Courses/Details/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(c => c.Course) //theninclude för att traversera activities osv
                .FirstOrDefaultAsync(m => m.Id == id);
            //var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == user.CourseId);
            //user.Course = course;

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "Teacher")]
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
            userView.Role = roles.FirstOrDefault(r => r.Contains("Studen") || r.Contains("Teacher"));

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
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,CourseId")] UserViewModel viewUser)
        {
            if (id == null)
            {
                return NotFound();
            }

            //get user form DB with Id
            var userToUpdate = await _userManager.FindByIdAsync(id);
            //copy properties from UserViewModel to user (Des, Srce)
            PropertyCopier.CopyTo(viewUser, userToUpdate);
            //remove old role and add the new one 
            //var roles = await _userManager.GetRolesAsync(userToUpdate);
            //var oldRole = roles.FirstOrDefault(r => r.Contains("Student") || r.Contains("Teacher"));
            //string newRole = "";
            //if (oldRole != viewUser.Role)
            //{
            //    if (viewUser.Role == "Student") newRole = "Student";
            //    else newRole = "Teacher";
            //    var removeRoleResult = await _userManager.RemoveFromRoleAsync(userToUpdate, oldRole);
            //    if (!removeRoleResult.Succeeded) throw new Exception(string.Join("\n", removeRoleResult.Errors));
            //    var addToRoleResult = await _userManager.AddToRoleAsync(userToUpdate, newRole);
            //    if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));

            //}
            // add course to user
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == viewUser.CourseId);
            userToUpdate.Course = course;
            //check if the role is added or not 
            
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

            CourseDropDownList(viewUser.CourseId);
            
            //ViewData["Role"] = new SelectList(_roleManager.Roles, "Name", "Name", roles[0]);
            return View(viewUser);
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AddCourse(int? id)
        {
            var studentUser = await _userManager.GetUsersInRoleAsync("Student");
            //var adminUsers = await _userManager.GetUsersInRoleAsync("Teacher");
            var availableUsers = new List<User>();
            
            foreach (var item in studentUser)
            {
                if (item.CourseId == null) availableUsers.Add(item);
            }
         
            //var usedUsers = await _context.Users.Where(u => u.CourseId == id).ToListAsync();
            var course = await _context.Courses.FindAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            ViewData["Users"] = new SelectList(availableUsers, "Id", "Email");
            ViewData["coursename"] = course.Name;
            //ViewData["coursid"] = id;
            ViewBag.courseid = id;
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AddCourse(int? id1, [Bind("Id,Email")] User user)
        {
            var userToUpdate = await _userManager.FindByIdAsync(user.Id);
            if (id1 == null)
            {
                return NotFound();
            }
            userToUpdate.CourseId = id1;
            var availableUsers = _context.Users.Where(u => u.CourseId == null).ToList();

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
                return RedirectToAction("AddCourse", new { id = id1 });
            }
            ViewData["Users"] = new SelectList(availableUsers, "Id", "Email");

            return View(userToUpdate);
        }

        // GET: users/Delete/5
        [Authorize(Roles = "Teacher")]
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
        [Authorize(Roles = "Teacher")]

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
            
            ViewData["courseId"] = new SelectList(courseQuery.AsNoTracking(), "Id", "Name", selectedCourse);
        }        
    }
}