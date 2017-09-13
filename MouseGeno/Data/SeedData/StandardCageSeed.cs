using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MouseGeno.Models;

namespace MouseGeno.Data.SeedData
{
    public class StandardCageSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Cage.Any(x => x.Breeding == false))
            {
                //Standard cages alrady seeded
            }
            else
            {
                for (int num = 1; num <= 150; num++)
                {
                    context.Cage.AddRangeAsync(
                    new Cage
                    {
                        CageNumber = $"SK-{num}",
                        Breeding = false
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
