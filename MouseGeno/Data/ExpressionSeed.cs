using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MouseGeno.Models;

namespace MouseGeno.Data
{
    public class ExpressionSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context = serviceProvider.GetService<ApplicationDbContext>();

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
