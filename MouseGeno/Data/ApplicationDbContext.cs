using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MouseGeno.Models;

namespace MouseGeno.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Cage> Cage { get; set; }

        public DbSet<CageCondition> CageCondition { get; set; }

        public DbSet<Condition> Condition { get; set; }

        public DbSet<GeneExpression> GeneExpression { get; set; }

        public DbSet<GenoType> GenoType { get; set; }

        public DbSet<HealthStatus> HealthStatus { get; set; }

        public DbSet<Line> Line { get; set; }

        public DbSet<Mouse> Mouse { get; set; }

        public DbSet<MouseCage> MouseCage { get; set; }

        public DbSet<MouseHealthStatus> MouseHealthStatus { get; set; }

        public DbSet<MouseTask> MouseTask { get; set; }

        public DbSet<TaskType> TaskType { get; set; }
    }
}
