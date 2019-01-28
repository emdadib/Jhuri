using Jhuri.Data;
using Jhuri.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.Code
{
    public class IdentityDbInitializer
    {
        public static ApplicationDbContext _context;

        public IdentityDbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public static void SeedData(UserManager<ApplicationUsers> userManager, RoleManager<ApplicationRoles> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUsers> userManager)
        {
            if(userManager.FindByNameAsync("Emdad").Result == null)
            {
                ApplicationUsers user = new ApplicationUsers
                {
                    UserName = "Emdad",
                    Email = "emdad@localhost.com",
                    Name = "Emdad",
                    DateOfBirth = new DateTime(1996, 1, 2),
                };
                IdentityResult result = userManager.CreateAsync(user, "12345678").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                ApplicationUsers user = new ApplicationUsers
                {
                    UserName = "Admin",
                    Email = "admin@localhost.com",
                    Name = "Emdadul Islam",
                    DateOfBirth = new DateTime(1993, 1, 2),
                };
                IdentityResult result = userManager.CreateAsync(user, "12345678").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<ApplicationRoles> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                ApplicationRoles role = new ApplicationRoles
                {
                    Name = "User",
                    Description = "Perform normal operation."
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                ApplicationRoles role = new ApplicationRoles
                {
                    Name = "Admin",
                    Description = "Perform All operation."
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Editor").Result)
            {
                ApplicationRoles role = new ApplicationRoles
                {
                    Name = "Editor",
                    Description = "Can Perform All Edit operation."
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }


        }
    }
}
