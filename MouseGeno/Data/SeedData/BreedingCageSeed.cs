using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MouseGeno.Models;

namespace MouseGeno.Data.SeedData
{
    public class BreedingCageSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Cage.Any(x => x.Breeding == true))
            {
                //breeding cages alrady seeded
            }
            else
            {
                context.Cage.AddRange(
                    new Cage
                    {
                        CageNumber = "SKB-1",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-2",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-3",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-4",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-5",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-6",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-7",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-8",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-9",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-10",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-11",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-12",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-13",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-14",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-15",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-16",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-17",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-18",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-19",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-20",
                        Breeding = true
                    },
                    new Cage
                    {
                        CageNumber = "SKB-21",
                        Breeding = true
                    }, 
                    new Cage
                    {
                        CageNumber = "SKB-22",
                        Breeding = true
                    }


                  );

                context.SaveChanges();
            }

        }
    }
}
