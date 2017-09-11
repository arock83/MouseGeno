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

        public DbSet<MouseGeno.Models.Cage> Cage { get; set; }

        public DbSet<MouseGeno.Models.Condition> Condition { get; set; }

        public DbSet<MouseGeno.Models.GenoType> GenoType { get; set; }

        public DbSet<MouseGeno.Models.HealthStatus> HealthStatus { get; set; }

        public DbSet<MouseGeno.Models.Line> Line { get; set; }

        public DbSet<MouseGeno.Models.Mouse> Mouse { get; set; }

        public DbSet<MouseGeno.Models.TaskType> TaskType { get; set; }

        public DbSet<MouseGeno.Models.CageCondition> CageCondition { get; set; }

        public DbSet<MouseGeno.Models.LineGenoType> LineGenoType { get; set; }

        public DbSet<MouseGeno.Models.MouseCage> MouseCage { get; set; }

        public DbSet<MouseGeno.Models.MouseHealthStatus> MouseHealthStatus { get; set; }

        public DbSet<MouseGeno.Models.MouseTask> MouseTask { get; set; }
    }
}
