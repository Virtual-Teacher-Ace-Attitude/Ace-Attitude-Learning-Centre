using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface ICourseService
    {
        Course GetById(int id);

        Course CreateCourse(Course course, ApplicationUser user);

        Course DeleteCourse(int id, ApplicationUser user);

        Course UpdateCourse(int id, Course course, ApplicationUser user);

        List<Course> GetAll(string filterParam, string filterParamValue, string sortParam);

        Course RateCourse(int id, Rating rating, ApplicationUser user);
    }
}
