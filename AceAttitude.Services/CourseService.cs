

using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;

namespace AceAttitude.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public Course CreateCourse(Course course, ApplicationUser user)
        {
            //Must be a teacher or admin
            return courseRepository.CreateCourse(course);
        }

        public Course DeleteCourse(int id, ApplicationUser user)
        {
            //Must be a teacher or admin
            return courseRepository.DeleteCourse(id);
        }

        public Course GetById(int id)
        {
            return courseRepository.GetById(id);
        }

        public Course UpdateCourse(int id, Course course, ApplicationUser user)
        {
            //must be a teacher or admin
            return courseRepository.UpdateCourse(id, course);
        }

        public List<Course> GetAll(string filterParam, string filterParamValue, string sortParam) 
        {
            return courseRepository.GetFilteredCourses(filterParam, filterParamValue, sortParam);
        }

        public Course RateCourse(int id, Rating rating, ApplicationUser user)
        {
            //must be a student
            return courseRepository.RateCourse(id, rating);
        }
    }
}
