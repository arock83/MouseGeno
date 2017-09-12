using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MouseGeno.Models;

namespace MouseGeno.Data.SeedData
{
    public class HealthStatusSeed
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.HealthStatus.Any())
            {
                //Condition table already seeded
            }
            else
            {
                context.HealthStatus.AddRange(
                    new HealthStatus
                    {
                        Name = "Clubbed Feet",
                        Description = "One foot or both appear to have been rotated internally at the ankle."
                    },
                    new HealthStatus
                    {
                        Name = "Tremor",
                        Description = "An involuntary quivering movement."
                    },
                    new HealthStatus
                    {
                        Name = "Hind Limb Crawl",
                        Description = ""
                    },
                    new HealthStatus
                    {
                        Name = "Lethargy",
                        Description = "A lack of energy and enthusiasm."
                    },
                    new HealthStatus
                    {
                        Name = "Hair Lose",
                        Description = ""
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
