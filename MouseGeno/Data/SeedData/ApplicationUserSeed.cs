using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MouseGeno.Models;

namespace MouseGeno.Data.SeedData
{
    public class ApplicationUserSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.ApplicationUser.Any())
            {
                //Application User Table alrady seeded
            }
            else
            {

            }
        }
    }
}
