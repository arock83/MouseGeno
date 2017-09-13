using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MouseGeno.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace MouseGeno.Data.SeedData
{
    public class ApplicationUserSeed
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var _context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Create the Admin Role
            if (!_context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                await roleManager.CreateAsync(role);
                _context.SaveChanges();
            }

            if (!_context.Users.Any(u => u.UserName == "Admin"))
            {
                await userManager.CreateAsync(
                 new ApplicationUser
                 {
                     UserName = "Admin",
                     NormalizedUserName = "ADMIN",
                     Email = "arock83@gmail.com",
                     NormalizedEmail = "AROCK83@GMAIL.COM",
                     Name = "Admin",
                     Initials = "Adm",
                     EmailConfirmed = true,

                }, "MouseGeno901!");
                _context.SaveChanges();

                //Code to Add to Admin Role Breaks!!!!
                //await userManager.AddToRoleAsync(await userManager.FindByNameAsync(userName: "Admin"), "Admin");
                //_context.SaveChanges();
            }

        }
    }
}
