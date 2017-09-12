using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MouseGeno.Models;

namespace MouseGeno.Data.SeedData
{
    public class ConditionSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Condition.Any())
            {
                //Condition table already seeded
            }
            else
            {
                context.Condition.AddRange(
                    new Condition
                    {
                        Name = "Switch Food to Standard",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Switch Water to Standard",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Refresh Cage",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Add Heating Pad",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Remove Heating Pad",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Overnight Fast",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "24 hour Fast",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "48 hour Fast",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Replace Bedding with Grid",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Replace Grid with Bedding",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Switch to Drug Treated Food",
                        Instructions = ""
                    },
                    new Condition
                    {
                        Name = "Switch to Drug Treated Water",
                        Instructions = ""
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
