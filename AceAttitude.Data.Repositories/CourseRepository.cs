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
            throw new NotImplementedException();
        }

        public Course DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Course GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Course UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
