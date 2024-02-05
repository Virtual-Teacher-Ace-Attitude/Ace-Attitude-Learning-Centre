using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface ICourseService
    {
        Course GetById(int id);

        Course CreateCourse(Course course, Teacher teacher);

        Course DeleteCourse(int id, Teacher teacher);

        Course UpdateCourse(int id, Course course, Teacher teacher);

        List<Course> GetAll(string filterParam, string filterParamValue, string sortParam);

        Course RateCourse(int id, Rating rating, Student student);
    }
}
