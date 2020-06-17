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

                var roleNames = new[] { "Admin", "Member" };

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


                //{ "Username", "Email", "FirstName", LastName" }
                var userArray = new[,] {
                    { adminEmail, adminEmail, "Admin", "Adminsson" },
                    { "anders@microsoft.com","anders@microsoft.com", "Anders", "Nilsson" },
                    { "eva.bjork@sr.se", "eva.bjork@sr.se", "Eva", "Björk" },
                    { "gunnar.munk@tele2.se", "gunnar.munk@tele2.se", "Gunnar", "Munk" },
                    { "jan@janne.org", "jan@janne.org", "Jan", "Ivarsson" },
                    { "hubert@murmur.com", "hubert@murmur.com", "Hubert", "Mur" }
                };

                for (int i = 0; i < userArray.GetLength(0); i++)
                {
                    var users = new User
                    {
                        UserName = userArray[i, 0],
                        Email = userArray[i, 1],
                        FirstName = userArray[i, 2],
                        LastName = userArray[i, 3]
                    };
                    var addUserResulttst = await userManager.CreateAsync(users, "a123");
                    if (!addUserResulttst.Succeeded) throw new Exception(string.Join("\n", addUserResulttst.Errors));
                    var auser = await userManager.FindByNameAsync(users.Email);

                    if (auser.Email == adminEmail)
                    {
                        foreach (var role in roleNames)
                        {
                            if (await userManager.IsInRoleAsync(auser, role)) continue;
                            var addToRoleResult = await userManager.AddToRoleAsync(auser, role);
                            if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));
                        }
                    }
                    foreach (var role in roleNames)
                    {
                        if (await userManager.IsInRoleAsync(auser, role)) continue;
                        var addToRoleResult = await userManager.AddToRoleAsync(auser, "Member");
                        if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));
                    }
                }
            }
        }
    }
}
