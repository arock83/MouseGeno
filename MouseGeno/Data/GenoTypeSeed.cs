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
                        context.GenoType.AddRange(
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
                        context.SaveChanges();
                    }
                }
            }

        }
    }
}
