

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
            throw new NotImplementedException();
        }

        public Course DeleteCourse(int id, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Course GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Course UpdateCourse(int id, Course course, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
