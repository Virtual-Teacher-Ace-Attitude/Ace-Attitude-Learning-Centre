
using Microsoft.EntityFrameworkCore;

using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;

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

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourses> StudentCourses { get; set; }

        public DbSet<StudentSubmissions> StudentSubmissions { get; set; }

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

            string standardPassword = "$2a$11$p4falukZH9ovaApIH6O1T.TbAbwVphyDAVkg2YaFYF7LE6/f79a.6"; // Telerik*01

            DateTime standardCreationDate = DateTime.Now;

            List<ApplicationUser> users = new List<ApplicationUser>
{
                // Students
                new ApplicationUser
                {
                    Id = student1Id,
                    Email = "sarah.smith@example.com",
                    PasswordHash = standardPassword,
                    FirstName = "Sarah",
                    LastName = "Smith",
                    StudentId = student1Id,
                    CreatedOn = standardCreationDate,
                    UserType = UserType.Student,
                },

                new ApplicationUser
                {
                    Id = student2Id,
                    Email = "john.doe@example.com",
                    PasswordHash = standardPassword,
                    FirstName = "John",
                    LastName = "Doe",
                    StudentId = student2Id,
                    CreatedOn = standardCreationDate.AddDays(1),
                    UserType = UserType.Student,
                },

                new ApplicationUser
                {
                    Id = student3Id,
                    Email = "emily.jackson@example.com",
                    PasswordHash = standardPassword,
                    FirstName = "Emily",
                    LastName = "Jackson",
                    StudentId = student3Id,
                    CreatedOn = standardCreationDate.AddDays(2),
                    UserType = UserType.Student,
                },
            
                // Teachers
                new ApplicationUser
                {
                    Id = teacher1Id,
                    Email = "alexander.arabadzhiev@example.com",
                    PasswordHash = standardPassword,
                    FirstName = "Alexander",
                    LastName = "Arabadzhiev",
                    TeacherId = teacher1Id,
                    CreatedOn = standardCreationDate,
                    UserType = UserType.Admin,
                },

                new ApplicationUser
                {
                    Id = teacher2Id,
                    Email = "alexei.kalionski@example.com",
                    PasswordHash = standardPassword,
                    FirstName = "Alexei",
                    LastName = "Kalionski",
                    TeacherId = teacher2Id,
                    CreatedOn = standardCreationDate.AddDays(1),
                    UserType = UserType.Admin,
                },

                new ApplicationUser
                {
                    Id = teacher3Id,
                    Email = "georgi.aleksandrov@example.com",
                    PasswordHash = standardPassword,
                    FirstName = "Georgi",
                    LastName = "Aleksandrov",
                    TeacherId = teacher3Id,
                    CreatedOn = standardCreationDate.AddDays(2),
                    UserType = UserType.Teacher,
                },
            };

            modelBuilder.Entity<ApplicationUser>().HasData(users);

            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id = student1Id,
                    ApplicationUserId = student1Id,
                },

                new Student
                {
                    Id = student2Id,
                    ApplicationUserId = student2Id,
                },

                new Student
                {
                    Id = student3Id,
                    ApplicationUserId = student3Id,
                },
            };

            modelBuilder.Entity<Student>().HasData(students);

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher
                {
                    Id = teacher1Id,
                    ApplicationUserId = teacher1Id,
                    IsAdmin = true,
                    IsApproved = true,
                },

                new Teacher
                {
                    Id = teacher2Id,
                    ApplicationUserId = teacher2Id,
                    IsAdmin = true,
                    IsApproved = true,
                },

                new Teacher
                {
                    Id = teacher3Id,
                    ApplicationUserId = teacher3Id,
                    IsAdmin = false,
                    IsApproved = true,
                }
            };

            modelBuilder.Entity<Teacher>().HasData(teachers);

            List<Lecture> lectures = new List<Lecture>
            {
                new Lecture
                {
                    Id = 1,
                    CourseId = 1,
                    Title = "Classroom Language",
                    Description = "Teaches kids basic vocabulary related to the classroom and classroom activities.",
                    CreatedOn = standardCreationDate,
                },

                new Lecture
                {
                    Id = 2,
                    CourseId = 2,
                    Title = "Introductions and Icebreakers",
                    Description = "A speaking-oriented lecture for teenagers.",
                    CreatedOn = standardCreationDate.AddDays(1),
                },

                new Lecture
                {
                    Id = 3,
                    CourseId = 3,
                    Title = "Literature Appreciation",
                    Description = "An in-depth analysis of classic and contemporary literary works.",
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
                    Title = "Oxford Adventurers",
                    Description = "This course introduces fundamental English language skills and phonics to preschool children.",
                    Level = Level.A1,
                    AgeGroup = AgeGroup.Kids,
                    IsDraft = false,
                    IsCompleted = true,
                    StartingDate = standardCreationDate,
                    CreatedOn = standardCreationDate,
                },

                new Course
                {
                    Id = 2,
                    TeacherId = teacher2Id,
                    Title = "First Certificate for Schools",
                    Description = "This course thoroughly prepares high school students for their inaugural certification exam.",
                    Level = Level.B2,
                    AgeGroup = AgeGroup.Teens,
                    IsDraft = false,
                    IsCompleted = false,
                    StartingDate = standardCreationDate.AddMonths(1),
                    CreatedOn = standardCreationDate.AddDays(7),
                },

                new Course
                {
                    Id = 3,
                    TeacherId = teacher3Id,
                    Title = "Creative Writing Masterclass",
                    Description = "Unlock your creativity with this masterclass on creative writing techniques and storytelling.",
                    Level = Level.C2,
                    AgeGroup = AgeGroup.Adults,
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
                    Content = "I found the first lecture very informative. Looking forward to the rest of the course!",
                    Likes = 5,
                    CreatedOn = standardCreationDate.AddDays(1),
                },

                new Comment
                {
                    Id = 2,
                    CourseId = 2,
                    ApplicationUserId = student2Id,
                    Content = "The workshop materials are comprehensive and well-organized. Enjoying the learning experience!",
                    Likes = 7,
                    CreatedOn = standardCreationDate.AddDays(14),
                },

                new Comment
                {
                    Id = 3,
                    CourseId = 3,
                    ApplicationUserId = student3Id,
                    Content = "The masterclass has inspired me to start working on my novel. Thank you!",
                    Likes = 10,
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
                    Value = 4.8m,
                    CreatedOn = standardCreationDate.AddDays(3),
                    IsRated = true,
                },

                new Rating
                {
                    Id = 2,
                    CourseId = 1,
                    StudentId = student2Id,
                    Value = 4.6m,
                    CreatedOn = standardCreationDate.AddDays(4),
                    IsRated = true,
                },

                new Rating
                {
                    Id = 3,
                    CourseId = 1,
                    StudentId = student3Id,
                    Value = 4.7m,
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
                    IsApproved = true,
                },

                new StudentCourses
                {
                    Id = 2,
                    StudentId = student2Id,
                    CourseId = 1,
                    IsCompleted = true,
                    CreatedOn = standardCreationDate.AddDays(-4),
                    IsApproved = true,
                },

                new StudentCourses
                {
                    Id = 3,
                    StudentId = student3Id,
                    CourseId = 1,
                    IsCompleted = true,
                    CreatedOn = standardCreationDate.AddDays(-5),
                    IsApproved = true,
                },

                new StudentCourses
                {
                    Id = 4,
                    StudentId = student1Id,
                    CourseId = 2,
                    IsCompleted = false,
                    CreatedOn = standardCreationDate.AddDays(8),
                    IsApproved = true,
                },

                new StudentCourses
                {
                    Id = 5,
                    StudentId = student2Id,
                    CourseId = 2,
                    IsCompleted = false,
                    CreatedOn = standardCreationDate.AddDays(9),
                    IsApproved = true,
                },

                new StudentCourses
                {
                    Id = 6,
                    StudentId = student3Id,
                    CourseId = 2,
                    IsCompleted = false,
                    CreatedOn = standardCreationDate.AddDays(10),
                    IsApproved = true,
                },
            };
            modelBuilder.Entity<StudentCourses>().HasData(studentCourses);
        }
    }
}