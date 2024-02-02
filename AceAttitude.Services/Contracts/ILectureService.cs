

using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Services.Contracts
{
    public interface ILectureService
    {
        Lecture GetById(int id);

        Lecture CreateLecture(Lecture lecture, Course course, ApplicationUser user);

        Lecture UpdateLecture(int id, Lecture lecture, ApplicationUser user);

        Lecture DeleteLecture(int id, ApplicationUser user);
    }
}
