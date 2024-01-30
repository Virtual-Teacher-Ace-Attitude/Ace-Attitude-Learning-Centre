

using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface ILectureService
    {
        ILecture GetById(int id);

        ILecture CreateLecture(ILecture lecture, IApplicationUser user);

        ILecture UpdateLecture(int id, ILecture lecture, IApplicationUser user);

        ILecture DeleteLecture(int id, IApplicationUser user);
    }
}
