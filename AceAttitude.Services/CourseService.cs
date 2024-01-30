

using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;

namespace AceAttitude.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService (ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }   
        public ICourse CreateCourse(ICourse course, IApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public ICourse DeleteCourse(int id, IApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public ICourse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICourse UpdateCourse(int id, ICourse course, IApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
