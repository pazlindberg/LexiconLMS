using LexiconLMS.Data;
using LexiconLMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace LexiconLMS
{
    public static class SeedData
    {
        public static async System.Threading.Tasks.Task InitializeAsync(IServiceProvider services, string adminPW)
        {
            var options = services.GetRequiredService<DbContextOptions<ApplicationDbContext>>();

            using (var context = new ApplicationDbContext(options))
            {
                //Skapa managers för att hantera Users och Roles
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                var roleNames = new[] { "Teacher", "Student" };

                foreach (var name in roleNames)
                {
                    //Om rollen finns fortsätt med nästa i "listan"
                    if (await roleManager.RoleExistsAsync(name)) continue;

                    //Annars skapa rollen
                    var role = new IdentityRole { Name = name };
                    var result = await roleManager.CreateAsync(role);

                    //Om nåt går fel kasta en exception
                    if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
                }

                var adminEmail = "a@a.se";

                var foundUser = await userManager.FindByEmailAsync(adminEmail);

                if (foundUser != null) return;

                var user = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Teacher",
                    LastName = "qwdoihioudqwuqwuui",
                    //TimeOfRegistration = DateTime.Now
                };
                var uemail2 = "info@microsoft.com";
                var user2 = new User
                {
                    UserName = uemail2,
                    Email = uemail2,
                    FirstName = "Elev1",
                    LastName = "Bin Laden",
                    //TimeOfRegistration = DateTime.Now
                };
                var uemail3 = "ringp1@sr.se";
                var user3 = new User
                {
                    UserName = uemail3,
                    Email = uemail3,
                    FirstName = "Dårradion",
                    LastName = "Dåre",
                    //TimeOfRegistration = DateTime.Now
                };

                var addUserResult = await userManager.CreateAsync(user, "a123");
                var addUserResult2 = await userManager.CreateAsync(user2, "a123");
                var addUserResult3 = await userManager.CreateAsync(user3, "a123");

                if (!addUserResult.Succeeded) throw new Exception(string.Join("\n", addUserResult.Errors));
                
                if (!addUserResult2.Succeeded) throw new Exception(string.Join("\n", addUserResult2.Errors));
                
                if (!addUserResult3.Succeeded) throw new Exception(string.Join("\n", addUserResult3.Errors));


                var adminUser = await userManager.FindByNameAsync(adminEmail);
                var auser2 = await userManager.FindByNameAsync(uemail2);
                var auser3 = await userManager.FindByNameAsync(uemail3);

                foreach (var role in roleNames)
                {
                    if (await userManager.IsInRoleAsync(adminUser, role)) continue;

                    var addToRoleResult = await userManager.AddToRoleAsync(adminUser, role);

                    if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));

                    //2
                    if (await userManager.IsInRoleAsync(auser2, role)) continue;

                    addToRoleResult = await userManager.AddToRoleAsync(auser2, "Student"); //todo: sen när rollerna ändras med ahmads commit måste detta ändras

                    if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));

                    //3
                    if (await userManager.IsInRoleAsync(auser3, role)) continue;

                    addToRoleResult = await userManager.AddToRoleAsync(auser3, "Student");

                    if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));
                }




            }
        }
    }
}
