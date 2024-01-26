

using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ICourseRepository
    {
        ICourse GetById(int id);

        ICourse CreateCourse (ICourse course);

        ICourse UpdateCourse (ICourse course);

        ICourse DeleteCourse (int id);
    }
}
