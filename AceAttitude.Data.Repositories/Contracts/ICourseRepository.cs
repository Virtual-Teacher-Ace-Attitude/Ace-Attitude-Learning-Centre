

using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ICourseRepository
    {
        Course GetById(int id);

        Course CreateCourse (Course course);

        Course UpdateCourse (Course course);

        Course DeleteCourse (int id);
    }
}
