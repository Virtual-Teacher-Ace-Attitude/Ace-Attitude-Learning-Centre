
using Microsoft.EntityFrameworkCore;

using AceAttitude.Data.Models;


namespace AceAttitude.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> Users { get; set; }

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

            string student1Id = "64dfe826-08e8-4dcf-888b-c441fead8803";
            string student2Id = "11d15832-b94e-4be4-a892-14a07641adc3";
            string student3Id = "5422e8d8-d114-42b1-b878-f410f14e0be7";

            string teacher1Id = "22cbe4de-2827-4458-b55f-779a19400ab5";
            string teacher2Id = "aba81718-3f23-42ca-ba84-fcd9b4f4f944";
            string teacher3Id = "89beab74-07ac-446a-8dc6-b0291b5ff68b";

            string standardPassword = "2a$11$2Wp6Wd8XCZRnMj9WoPYeCeiQTL9Xv7OQmYtaiKgGCvmUzgbUUYQsa"; // Telerik*01

            DateTime standardCreationDate = DateTime.Now;

            List<ApplicationUser> users = new List<ApplicationUser>
            {
                // Students
                new ApplicationUser
                {
                    Id = student1Id,
                    Email = "student1@abv.bg",
                    PasswordHash = standardPassword,
                    FirstName = "Student",
                    LastName = "One",
                    StudentId = student1Id,
                    CreatedOn = standardCreationDate,
                },

                new ApplicationUser
                {
                    Id = student2Id,
                    Email = "student2@abv.bg",
                    PasswordHash = standardPassword,
                    FirstName = "Student",
                    LastName = "Two",
                    StudentId = student2Id,
                    CreatedOn = standardCreationDate.AddDays(1),
                },

                new ApplicationUser
                {
                    Id = student3Id,
                    Email = "student3@abv.bg",
                    PasswordHash = standardPassword,
                    FirstName = "Student",
                    LastName = "Three",
                    StudentId = student3Id,
                    CreatedOn = standardCreationDate.AddDays(2),
                },

                // Teachers
                new ApplicationUser
                {
                    Id = teacher1Id,
                    Email = "teacher1@abv.bg",
                    PasswordHash = standardPassword,
                    FirstName = "Alexei",
                    LastName = "Kalionski",
                    TeacherId = teacher1Id,
                    CreatedOn = standardCreationDate,
                },

                new ApplicationUser
                {
                    Id = teacher2Id,
                    Email = "teacher2@abv.bg",
                    PasswordHash = standardPassword,
                    FirstName = "Alexander",
                    LastName = "Arabadzhiev",
                    TeacherId = teacher2Id,
                    CreatedOn = standardCreationDate.AddDays(1),
                },

                new ApplicationUser
                {
                    Id = teacher3Id,
                    Email = "teacher3@abv.bg",
                    PasswordHash = standardPassword,
                    FirstName = "Georgi",
                    LastName = "Aleksandrov",
                    TeacherId = teacher3Id,
                    CreatedOn = standardCreationDate.AddDays(2),
                },
            };

            modelBuilder.Entity<ApplicationUser>().HasData(users);

            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id = student1Id,
                    ApplicationUserId = student1Id,
                    CreatedOn = standardCreationDate,
                },

                new Student
                {
                    Id = student2Id,
                    ApplicationUserId = student2Id,
                    CreatedOn = standardCreationDate.AddDays(1),
                },

                new Student
                {
                    Id = student3Id,
                    ApplicationUserId = student3Id,
                    CreatedOn = standardCreationDate.AddDays(2),
                },
            };

            modelBuilder.Entity<Student>().HasData(students);

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher
                {
                    Id = teacher1Id,
                    ApplicationUserId = teacher1Id,
                    CreatedOn = standardCreationDate,
                    IsAdmin = true,
                },

                new Teacher
                {
                    Id = teacher2Id,
                    ApplicationUserId = teacher2Id,
                    CreatedOn = standardCreationDate.AddDays(1),
                    IsAdmin = true,
                },

                new Teacher
                {
                    Id = teacher3Id,
                    ApplicationUserId = teacher3Id,
                    CreatedOn = standardCreationDate.AddDays(2),
                    IsAdmin = false,
                }
            };

            modelBuilder.Entity<Teacher>().HasData(teachers);

            List<Lecture> lectures = new List<Lecture>
            {
                new Lecture
                {
                    Id = 1,
                    CourseId = 1,
                    Title = "Lecture 1",
                    Description = "Description of lecture 1.",
                    CreatedOn = standardCreationDate,
                },

                new Lecture
                {
                    Id = 2,
                    CourseId = 2,
                    Title = "Lecture 2",
                    Description = "Description of lecture 2.",
                    CreatedOn = standardCreationDate.AddDays(1),
                },

                new Lecture
                {
                    Id = 3,
                    CourseId = 3,
                    Title = "Lecture 3",
                    Description = "Description of lecture 3.",
                    CreatedOn = standardCreationDate.AddDays(2),
                },
            };

            modelBuilder.Entity<Lecture>().HasData(lectures);

            List<Course> courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    TeacherId = teacher1Id,
                    Title = "Course 1",
                    Description = "Description of course 1.",
                    Level = Models.Misc.Level.A2,
                    AgeGroup = Models.Misc.AgeGroup.Kids,
                    IsDraft = false,
                    IsCompleted = true,
                    StartingDate = standardCreationDate,
                    CreatedOn = standardCreationDate,
                },

                new Course
                {
                    Id = 2,
                    TeacherId = teacher2Id,
                    Title = "Course 2",
                    Description = "Description of course 2.",
                    Level = Models.Misc.Level.B2,
                    AgeGroup = Models.Misc.AgeGroup.Teens,
                    IsDraft = false,
                    IsCompleted = false,
                    StartingDate = standardCreationDate.AddMonths(1),
                    CreatedOn = standardCreationDate.AddDays(7),
                },

                new Course
                {
                    Id = 3,
                    TeacherId = teacher3Id,
                    Title = "Course 3",
                    Description = "Description of course 3.",
                    Level = Models.Misc.Level.C2,
                    AgeGroup = Models.Misc.AgeGroup.Adults,
                    IsDraft = true,
                    IsCompleted = false,
                    StartingDate = standardCreationDate.AddMonths(2),
                    CreatedOn = standardCreationDate.AddMonths(1),
                },
            };

            modelBuilder.Entity<Course>().HasData(courses);

            List<Comment> comments = new List<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    CourseId = 1,
                    ApplicationUserId = student1Id,
                    Content = "Content of comment 1.",
                    Likes = 1,
                    CreatedOn = standardCreationDate.AddDays(1),
                },

                new Comment
                {
                    Id = 2,
                    CourseId = 2,
                    ApplicationUserId = student2Id,
                    Content = "Content of comment 2.",
                    Likes = 2,
                    CreatedOn = standardCreationDate.AddDays(14),
                },

                new Comment
                {
                    Id = 3,
                    CourseId = 3,
                    ApplicationUserId = student3Id,
                    Content = "Content of comment 3.",
                    Likes = 3,
                    CreatedOn = standardCreationDate.AddMonths(1).AddDays(3),
                },
            };

            modelBuilder.Entity<Comment>().HasData(comments);

            List<CommentLike> commentLikes = new List<CommentLike>
            {
                new CommentLike
                {
                    Id = 1,
                    CommentId = 1,
                    ApplicationUserId = student1Id,
                    CreatedOn = standardCreationDate.AddDays(1),
                    IsLiked = true,
                },

                new CommentLike
                {
                    Id = 2,
                    CommentId = 2,
                    ApplicationUserId = student2Id,
                    CreatedOn = standardCreationDate.AddDays(15),
                    IsLiked = true,
                },

                new CommentLike
                {
                    Id = 3,
                    CommentId = 3,
                    ApplicationUserId = student3Id,
                    CreatedOn = standardCreationDate.AddMonths(1).AddDays(5),
                    IsLiked = true,
                },

                new CommentLike
                {
                    Id = 4,
                    CommentId = 3,
                    ApplicationUserId = teacher3Id,
                    CreatedOn = standardCreationDate.AddMonths(1).AddDays(6),
                    IsLiked = false,
                }
            };

            modelBuilder.Entity<CommentLike>().HasData(commentLikes);

            List<Rating> ratings = new List<Rating>
            {
                new Rating
                {
                    Id = 1,
                    CourseId = 1,
                    StudentId = student1Id,
                    Value = 5.0m,
                    CreatedOn = standardCreationDate.AddDays(3),
                    IsRated = true,
                },

                new Rating
                {
                    Id = 2,
                    CourseId = 1,
                    StudentId = student2Id,
                    Value = 4.5m,
                    CreatedOn = standardCreationDate.AddDays(4),
                    IsRated = true,
                },

                new Rating
                {
                    Id = 3,
                    CourseId = 1,
                    StudentId = student3Id,
                    Value = 4.5m,
                    CreatedOn = standardCreationDate.AddDays(5),
                    IsRated = false,
                },
            };

            modelBuilder.Entity<Rating>().HasData(ratings);

            List<StudentCourses> studentCourses = new List<StudentCourses>
            {
                new StudentCourses
                {
                    Id = 1,
                    StudentId = student1Id,
                    CourseId = 1,
                    IsCompleted = true,
                    CreatedOn = standardCreationDate.AddDays(-3),
                },

                new StudentCourses
                {
                    Id = 2,
                    StudentId = student2Id,
                    CourseId = 1,
                    IsCompleted = true,
                    CreatedOn = standardCreationDate.AddDays(-4),
                },

                new StudentCourses
                {
                    Id = 3,
                    StudentId = student3Id,
                    CourseId = 1,
                    IsCompleted = true,
                    CreatedOn = standardCreationDate.AddDays(-5),
                },

                new StudentCourses
                {
                    Id = 4,
                    StudentId = student1Id,
                    CourseId = 2,
                    IsCompleted = false,
                    CreatedOn = standardCreationDate.AddDays(8),
                },

                new StudentCourses
                {
                    Id = 5,
                    StudentId = student2Id,
                    CourseId = 2,
                    IsCompleted = false,
                    CreatedOn = standardCreationDate.AddDays(9),
                },

                new StudentCourses
                {
                    Id = 6,
                    StudentId = student3Id,
                    CourseId = 2,
                    IsCompleted = false,
                    CreatedOn = standardCreationDate.AddDays(10),
                },
            };

            modelBuilder.Entity<StudentCourses>().HasData(studentCourses);
        }
    }
}