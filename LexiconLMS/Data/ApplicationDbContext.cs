using System;
using System.Collections.Generic;
using System.Text;
using LexiconLMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "Office 365",
                    Description = "Grundkurs i Office 365",
                    StartDate = new DateTime(2020, 06, 15)
                },
                new Course
                {
                    Id = 2,
                    Name = "Databaser 2",
                    Description = "Påbyggnadskurs i SQL",
                    StartDate = new DateTime(2020, 03, 20)
                },
                new Course
                {
                    Id = 3,
                    Name = "Test",
                    Description = "Hur man skriver tester",
                    StartDate = new DateTime(2020, 08, 01)
                },
                new Course
                {
                    Id = 4,
                    Name = "Programmering",
                    Description = "C#",
                    StartDate = new DateTime(2020, 01, 01)
                }
            );

            modelBuilder.Entity<Module>().HasData(
                new Module
                {
                    Id = 1,
                    Name = "Excel",
                    Description = "Skriva formler i Excel",
                    CourseId = 1,
                    StartDate = new DateTime(2020, 06, 15, 09, 00, 00),
                    EndDate = new DateTime(2020, 06, 20, 17, 00, 00)
                },
                new Module
                {
                    Id = 2,
                    Name = "Word",
                    Description = "Skriva dokument",
                    CourseId = 1,
                    StartDate = new DateTime(2020, 06, 21, 09, 00, 00),
                    EndDate = new DateTime(2020, 06, 30, 17, 00, 00)
                },
                new Module
                {
                    Id = 3,
                    Name = "Skapa databaser",
                    Description = "Skapa en enkel databas",
                    CourseId = 2,
                    StartDate = new DateTime(2020, 03, 20, 09, 00, 00),
                    EndDate = new DateTime(2020, 04, 10, 17, 00, 00)
                },
                new Module
                {
                    Id = 4,
                    Name = "Söka i databaser",
                    Description = "Hur söker man i en databas?",
                    CourseId = 2,
                    StartDate = new DateTime(2020, 04, 11, 09, 00, 00),
                    EndDate = new DateTime(2020, 04, 12, 17, 00, 00)
                },
                new Module
                {
                    Id = 5,
                    Name = "Arbeta med flera databaser",
                    Description = "Hur man ska arbeta med mer än en databas",
                    CourseId = 2,
                    StartDate = new DateTime(2020, 04, 13, 09, 00, 00),
                    EndDate = new DateTime(2020, 04, 20, 17, 00, 00)
                },
                new Module
                {
                    Id = 6,
                    Name = "Automatisering",
                    Description = "Automatisering av tester",
                    CourseId = 3,
                    StartDate = new DateTime(2020, 08, 01, 09, 00, 00),
                    EndDate = new DateTime(2020, 10, 20, 17, 00, 00)
                },
                new Module
                {
                    Id = 7,
                    Name = "Objekt",
                    Description = "Vad är objekt?",
                    CourseId = 4,
                    StartDate = new DateTime(2020, 01, 01, 09, 00, 00),
                    EndDate = new DateTime(2020, 12, 24, 15, 00, 00)
                }
            );

            modelBuilder.Entity<TaskType>().HasData(
                new TaskType
                {
                    Id = 1,
                    Name = "Föreläsning"
                },
                new TaskType
                {
                    Id = 2,
                    Name = "E-Learning"
                },
                new TaskType
                {
                    Id = 3,
                    Name = "Inlämningsuppgift"
                },
                new TaskType
                {
                    Id = 4,
                    Name = "Prov"
                },
                new TaskType
                {
                    Id = 5,
                    Name = "Certifiering"
                }
            );

            modelBuilder.Entity<Models.Task>().HasData(
                new Models.Task
                {
                    Id = 1,
                    Name = "Enkla formler(addition, subtraktion...)",
                    ModuleId = 1,
                    TaskTypeId = 1,
                    StartDate = new DateTime(2020, 06, 15, 09, 00, 00),
                    EndDate = new DateTime(2020, 06, 15, 14, 00, 00)
                },
                new Models.Task
                {
                    Id = 2,
                    Name = "Hur man använder ett tangentbord för att få tecken på skärmen",
                    ModuleId = 2,
                    TaskTypeId = 2,
                    StartDate = new DateTime(2020, 06, 21, 09, 00, 00),
                    EndDate = new DateTime(2020, 06, 22, 17, 00, 00)
                },
                new Models.Task
                {
                    Id = 3,
                    Name = "Skapa en databas för telefonnummer",
                    ModuleId = 3,
                    TaskTypeId = 3,
                    StartDate = new DateTime(2020, 03, 20, 09, 00, 00),
                    EndDate = new DateTime(2020, 04, 10, 17, 00, 00)
                },
                new Models.Task
                {
                    Id = 4,
                    Name = "Basic queries",
                    ModuleId = 4,
                    TaskTypeId = 2,
                    StartDate = new DateTime(2020, 04, 11, 10, 00, 00),
                    EndDate = new DateTime(2020, 04, 11, 15, 00, 00)
                },
                new Models.Task
                {
                    Id = 5,
                    Name = "Telefonnummer som är kopplade till en användare",
                    ModuleId = 5,
                    TaskTypeId = 4,
                    StartDate = new DateTime(2020, 04, 20, 10, 00, 00),
                    EndDate = new DateTime(2020, 04, 20, 12, 00, 00)
                },
                new Models.Task
                {
                    Id = 6,
                    Name = "Skriva ett test",
                    ModuleId = 6,
                    TaskTypeId = 1,
                    StartDate = new DateTime(2020, 08, 01, 09, 30, 00),
                    EndDate = new DateTime(2020, 08, 01, 11, 30, 00)
                },
                new Models.Task
                {
                    Id = 7,
                    Name = "Objektorienterad programmering",
                    ModuleId = 7,
                    TaskTypeId = 5,
                    StartDate = new DateTime(2020, 12, 23, 10, 00, 00),
                    EndDate = new DateTime(2020, 12, 23, 12, 00, 00)
                }
            );
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
    }
}
