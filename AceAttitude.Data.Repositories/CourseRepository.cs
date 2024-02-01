using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;

using AceAttitude.Data.Repositories.Contracts;

namespace AceAttitude.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext context;

        public CourseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Course CreateCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        public Course DeleteCourse(int id)
        {
            Course courseToDelete = GetById(id);
            courseToDelete.DeletedOn = DateTime.Now;
            context.SaveChanges();
            return courseToDelete;
        }

        public Course GetById(int id)
        {
            Course course = context.Courses.FirstOrDefault(c => c.Id == id) 
                ?? throw new EntityNotFoundException($"Course with id: {id} does not exist!");
            return course;
        }



        public Course UpdateCourse(int id, Course course)
        {
            Course courseToUpdate = GetById(id);
            courseToUpdate.Title = course.Title;
            courseToUpdate.Description = course.Description;
            courseToUpdate.AgeGroup = course.AgeGroup;
            courseToUpdate.Level = course.Level;
            courseToUpdate.ModifiedOn = DateTime.Now;

            context.SaveChanges();

            return courseToUpdate;
        }
        public decimal GetRating(int id)
        {
            Course course = GetById(id);
            return course.Ratings.Average(r => r.Value);
        }

        public Course RateCourse(int id, Rating rating)
        {
            Course courseToRate = GetById(id);
            courseToRate.Ratings.Add(rating);
            rating.IsRated = true;
            context.SaveChanges();
            return courseToRate;
        }
    }
}
