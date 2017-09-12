using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MouseGeno.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MouseGeno.Data.SeedData
{
    public class GenoTypeSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.GenoType.Any())
            {
                //user table seeded
            }
            else
            {
                //Build the GenoTypes by looping between Expression

                foreach (var x in context.GeneExpression)
                {
                    foreach (var y in context.GeneExpression)
                    {
                        context.GenoType.AddRangeAsync(
                            new GenoType
                            {
                                PK1 = x,
                                PK2 = y,
                                SynCre = true,
                            },
                            new GenoType
                            {
                                PK1 = x,
                                PK2 = y,
                                SynCre = false
                            }
                            );
                        
                    }
                }

                context.SaveChanges();
            }

        }
    }
}
