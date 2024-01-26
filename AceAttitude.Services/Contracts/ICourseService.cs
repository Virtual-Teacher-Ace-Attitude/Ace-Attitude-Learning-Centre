using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface ICourseService
    {
        ICourse GetById(int id);

        ICourse CreateCourse(ICourse course, IUser user);

        ICourse DeleteCourse(int id, IUser user);

        ICourse UpdateCourse(int id, ICourse course, IUser user);
    }
}
