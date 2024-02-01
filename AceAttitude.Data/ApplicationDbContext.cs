using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using AceAttitude.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AceAttitude.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentLike> CommentLikes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //// Seed roles
            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Student", NormalizedName = "STUDENT" },
            //    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Teacher", NormalizedName = "TEACHER" },
            //    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" }
            //);
        }
    }
}