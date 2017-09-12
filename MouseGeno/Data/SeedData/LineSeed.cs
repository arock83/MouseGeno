using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MouseGeno.Models;

namespace MouseGeno.Data.SeedData
{
    public class LineSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Line.Any())
            {
                //Task Type table seeded
            }
            else
            {
                context.Line.AddRange(
                    new Line
                    {
                        Name = "PK1 KO SynPK2",
                        Description = ""
                    },
                    new Line
                    {
                        Name = "SynPK1 SynPK2",
                        Description = ""
                    }
            
                    );
                context.SaveChanges();
            }

        }
    }
}
