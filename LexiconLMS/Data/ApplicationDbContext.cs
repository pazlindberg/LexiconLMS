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
                   Name = "Kurs1",
                   Description = "Kurs1beskrivning",
                   StartDate = DateTime.Now
               };

               var module = new Module
               {
                   Id = 1,
                   Name = "Module1",
                   Description = "Module1description",
                   CourseId=1,
                   StartDate = DateTime.Now,
                   EndDate = DateTime.Now
                   
               };

               var task = new Models.Task
               {
                   Id = 1,
                   Name = "Model1",
                   ModuleId=1,
                   TaskTypeId=1,
                   StartDate = DateTime.Now,
                   EndDate = DateTime.Now
               };

               var tasktype = new TaskType
               {
                   Id = 1,
                   Name = "Tasktype1"
               };
            
            modelBuilder.Entity<Course>().HasData(course);
            modelBuilder.Entity<Module>().HasData(module);
            modelBuilder.Entity<TaskType>().HasData(tasktype);
            modelBuilder.Entity<Models.Task>().HasData(task);


        }

        public DbSet<Course> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
