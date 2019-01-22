using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList
{
    public static class SeedData
    {
        public static async Task InitializeAsync(ToDoContext context, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            if (await userManager.FindByEmailAsync("admin@admin.admin") == null)
            {
                await roleManager.CreateAsync(new ApplicationRole { Description = "Administrator role", CreationDate = DateTime.Now, Name = "Administrator" });

                var user = new ApplicationUser
                {
                    FirstName = "Hristo",
                    LastName = "Atnasov",
                    City = "Plovdiv",
                    Country = "Bulgaria",
                    Email = "admin@admin.admin",
                    UserName = "admin@admin.admin"
                };

                await userManager.CreateAsync(user);

                await userManager.AddPasswordAsync(user, "C0nstalation!");
                await userManager.AddToRoleAsync(user, "Administrator");
            }
        }
    }
}
