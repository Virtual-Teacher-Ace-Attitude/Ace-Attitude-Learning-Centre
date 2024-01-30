using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface ICourseService
    {
        ICourse GetById(int id);

        ICourse CreateCourse(ICourse course, IApplicationUser user);

        ICourse DeleteCourse(int id, IApplicationUser user);

        ICourse UpdateCourse(int id, ICourse course, IApplicationUser user);
    }
}
