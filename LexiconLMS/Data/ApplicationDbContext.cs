using System;
using System.Collections.Generic;
using System.Text;
using LexiconLMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

               var course = new Course
               {
                   Id = 1,
                   Name = "Snuskurs",
                   Description = "mer om snus",
                   StartDate = DateTime.Now
               };
            
                var course2 = new Course
                {
                    Id = 2,
                    Name = "Särskrivningskurs",
                    Description = "mer om särskrivning",
                    StartDate = DateTime.Now
                };

                var course3 = new Course
                {
                    Id = 3,
                    Name = "Värdegrundskurs",
                    Description = "fest",
                    StartDate = DateTime.Now
                };

               var module = new Module
               {
                   Id = 1,
                   Name = "SNUS A",
                   Description = "Module1description",
                   CourseId=1,
                   StartDate = DateTime.Now,
                   EndDate = DateTime.Now
                   
               };
                var module2 = new Module
                {
                    Id = 2,
                    Name = "SNUS B",
                    Description = "Module1description",
                    CourseId = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now

                };
                var module3 = new Module
                {
                    Id = 3,
                    Name = "Värdegrund A",
                    Description = "Module1description",
                    CourseId = 3,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                };

               var task = new Models.Task
               {
                   Id = 1,
                   Name = "TASK 1 (snusa)",
                   ModuleId=1,
                   TaskTypeId=1,
                   StartDate = DateTime.Now,
                   EndDate = DateTime.Now
               };
            var task2 = new Models.Task
            {
                Id = 2,
                Name = "TASK 2 (snusa mer)",
                ModuleId = 2,
                TaskTypeId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            var task3 = new Models.Task
            {
                Id = 3,
                Name = "TASK 3 (snusa ännu mer)",
                ModuleId = 2,
                TaskTypeId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            var tasktype = new TaskType
               {
                   Id = 1,
                   Name = "Tasktype1"
               };
            var tasktype2 = new TaskType
            {
                Id = 2,
                Name = "Tasktype2"
            };
            var tasktype3 = new TaskType
            {
                Id = 3,
                Name = "Tasktype3"
            };

            modelBuilder.Entity<Course>().HasData(course);
            modelBuilder.Entity<Course>().HasData(course2);
            modelBuilder.Entity<Course>().HasData(course3);
            modelBuilder.Entity<Module>().HasData(module);
            modelBuilder.Entity<Module>().HasData(module2);
            modelBuilder.Entity<Module>().HasData(module3);
            modelBuilder.Entity<TaskType>().HasData(tasktype);
            modelBuilder.Entity<TaskType>().HasData(tasktype2);
            modelBuilder.Entity<TaskType>().HasData(tasktype3);
            modelBuilder.Entity<Models.Task>().HasData(task);
            modelBuilder.Entity<Models.Task>().HasData(task2);
            modelBuilder.Entity<Models.Task>().HasData(task3);


        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
