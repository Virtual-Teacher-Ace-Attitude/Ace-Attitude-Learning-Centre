using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using AceAttitude.Data.Models;

namespace AceAttitude.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = "1", Name = "Student", NormalizedName = "STUDENT" },
                new ApplicationRole { Id = "2", Name = "Teacher", NormalizedName = "TEACHER" },
                new ApplicationRole { Id = "3", Name = "Admin", NormalizedName = "ADMIN" }
            );

            
        }
    }
}