using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Common.Helpers.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AceAttitude.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private const string CourseNotFoundErrorMessage = "Course with id: {0} does not exist!";

        private readonly ApplicationDbContext courseContext;
        private readonly IParseHelper parseHelper;

        public CourseRepository(ApplicationDbContext context, IParseHelper parseHelper)
        {
            this.courseContext = context;
            this.parseHelper = parseHelper;
        }

        public Course CreateCourse(Course course)
        {
            course.CreatedOn = DateTime.Now;
            courseContext.Courses.Add(course);
            courseContext.SaveChanges();
            return course;
        }



        public Course DeleteCourse(int id)
        {
            Course courseToDelete = GetById(id);
            courseToDelete.DeletedOn = DateTime.Now;
            courseContext.SaveChanges();
            return courseToDelete;
        }

        public Course GetById(int id)
        {
            Course course = courseContext.Courses
                .Include(course => course.Lectures)
                .Include(course => course.Comments)
                .Include(course => course.Ratings)
                .FirstOrDefault(c => c.Id == id && c.DeletedOn.HasValue == false)
                ?? throw new EntityNotFoundException(string.Format(CourseNotFoundErrorMessage, id));
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

            courseContext.SaveChanges();

            return courseToUpdate;
        }
        public decimal GetRating(int id)
        {
            Course course = GetById(id);

            return course.Ratings.Select(r => r.Value).AsEnumerable().Average();
        }

        public Course RateCourse(int id, Rating rating)
        {
            Course courseToRate = GetById(id);
            courseToRate.Ratings.Add(rating);
            rating.IsRated = true;
            courseContext.SaveChanges();
            return courseToRate;
        }

        public IQueryable<Course> GetAll()
        {
            IQueryable<Course> allCourses = courseContext.Courses.Where(c => c.DeletedOn.HasValue == false)
                .Include(course => course.Ratings)
                .Include(course => course.Teacher)
                .ThenInclude(teacher => teacher.User);

            return allCourses;
        }

        public List<Course> GetFilteredCourses(string filterParam, string filterParamValue, string sortParam)
        {
            IQueryable<Course> filteredCourses = FilterCourses(filterParam, filterParamValue);
            return SortCourses(sortParam, filteredCourses).ToList();
        }

        private IQueryable<Course> FilterCourses(string filterParam, string paramValue)
        {

            switch (filterParam)
            {
                case "name":
                    return GetAll().Where(c => c.Title.Contains(paramValue));
                case "level":
                    Level level = parseHelper.ParseLevel(paramValue);
                    return GetAll().Where(c => c.Level == level);
                case "age":
                    AgeGroup age = parseHelper.ParseAge(paramValue);
                    return GetAll().Where(c => c.AgeGroup == age);
                case "teacher":
                    return GetAll().Where(c => c.Teacher.User.LastName == paramValue
                                            || c.Teacher.User.FirstName == paramValue);
                case "rating":
                    decimal rating = parseHelper.ParseRating(paramValue);
                    return GetAll().Where(c => GetRating(c.Id) >= rating);
                default:
                    return GetAll();

            }
        }

        private IQueryable<Course> SortCourses(string sortParam, IQueryable<Course> filteredCourses)
        {
            switch (sortParam)
            {
                case "name":
                    return filteredCourses.OrderByDescending(c => c.Title);
                case "rating":
                    return filteredCourses.OrderByDescending(c => GetRating(c.Id));
                case "name and rating":
                    return filteredCourses.OrderByDescending(c => GetRating(c.Id))
                        .ThenByDescending(c => c.Title);
                default:
                    return filteredCourses.OrderByDescending(c => c.StartingDate);
            }
        }
    }
}
