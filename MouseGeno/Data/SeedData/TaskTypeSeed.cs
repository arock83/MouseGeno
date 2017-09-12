using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MouseGeno.Models;

namespace MouseGeno.Data.SeedData
{
    public class TaskTypeSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.TaskType.Any())
            {
                //Task Type table seeded
            }
            else
            {
                context.TaskType.AddRange(
                    new TaskType
                    {
                        Name = "Weigh Mouse",
                        Instructions = "Record the Weight of the Mouse in grams",
                        MeasurementType = "g"
                    },
                    new TaskType
                    {
                        Name = "Terminate Mouse",
                        Instructions = ""
                    },
                    new TaskType
                    {
                        Name = "Oral Gavage",
                        Instructions = ""
                    },
                    new TaskType
                    {
                        Name = "Orbital Bleed",
                        Instructions = "",
                        MeasurementType = "ml"
                    },
                    new TaskType
                    {
                        Name = "IP Injection",
                        Instructions = "",
                        MeasurementType = "ml"
                    },
                    new TaskType
                    {
                        Name = "Move Mouse",
                        Instructions = ""
                    }
                    
                  );

                context.SaveChanges();
            }

        }
    }
}
