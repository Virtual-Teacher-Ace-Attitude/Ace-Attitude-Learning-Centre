

using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface ILectureService
    {
        ILecture GetById(int id);

        ILecture CreateLecture(ILecture lecture, IUser user);

        ILecture UpdateLecture(int id, ILecture lecture, IUser user);

        ILecture DeleteLecture(int id, IUser user);
    }
}
