

using AceAttitude.Data.Models;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ICourseRepository
    {
        Course GetById(int id);

        Course CreateCourse(Course course);

        Course UpdateCourse(int id, Course course);

        Course DeleteCourse(int id);

        Course RateCourse(int id, Rating rating);

        decimal GetRating(int Id);

        List<Course> GetFilteredCourses(string filterParam, string filterParamValue, string sortParam);

    }
}
