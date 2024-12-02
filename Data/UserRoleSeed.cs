using System.Linq;
using Microsoft.AspNetCore.Identity;
using BookLibraryApp.Models;

namespace BookLibraryApp.Data
{
    public static class UserRoleSeeder
    {
        public static void Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed Roles
            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                roleManager.CreateAsync(new IdentityRole("User")).Wait();
            }

            // Seed Admin User
            if (!userManager.Users.Any(u => u.UserName == "admin"))
            {
                var adminUser = new User
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(adminUser, "Admin@123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                }
            }

            // Seed Normal User
            if (!userManager.Users.Any(u => u.UserName == "user"))
            {
                var normalUser = new User
                {
                    UserName = "user",
                    Email = "user@example.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(normalUser, "User@123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(normalUser, "User").Wait();
                }
            }
        }
    }
}
