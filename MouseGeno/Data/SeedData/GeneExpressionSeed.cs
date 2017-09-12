using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MouseGeno.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MouseGeno.Data.SeedData
{
    public class GeneExpressionSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            
            if (context.GeneExpression.Any())
            {
                //user table seeded
            }
            else
            {
                context.GeneExpression.AddRange(
                    new GeneExpression
                    {
                        FullName = "WildType",
                        ShortHand = "WT"

                    },
                    new GeneExpression
                    {
                        FullName = "Heterozygous",
                        ShortHand = "HZ"
                    },
                    new GeneExpression
                    {
                        FullName = "Knockout",
                        ShortHand = "KO"
                    },
                    new GeneExpression
                    {
                        FullName = "Flux/Flux",
                        ShortHand = "FF"
                    },
                    new GeneExpression
                    {
                        FullName = "Flux/WildType",
                        ShortHand = "F+"
                    },
                    new GeneExpression
                    {
                        FullName = "Flux/Recessive",
                        ShortHand = "F-"
                    }
                  );

                context.SaveChanges();
            }

        }
    }
}
