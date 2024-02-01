

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
            //Must be a teacher.
            return courseRepository.CreateCourse(course);
        }

        public Course DeleteCourse(int id, ApplicationUser user)
        {
            //Must be a teacher/admin.
            return courseRepository.DeleteCourse(id);
        }

        public Course GetById(int id)
        {
            return courseRepository.GetById(id);
        }

        public Course UpdateCourse(int id, Course course, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
