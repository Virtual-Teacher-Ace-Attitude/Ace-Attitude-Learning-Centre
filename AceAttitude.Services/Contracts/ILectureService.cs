using AceAttitude.Data.Models;

namespace AceAttitude.Services.Contracts
{
    public interface ILectureService
    {
        Lecture GetById(int lectureId, int courseId, ApplicationUser user);

        Lecture CreateLecture(Lecture lecture, Course course, ApplicationUser user);

        Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture, ApplicationUser user);

        Lecture DeleteLecture(int lectureId, int courseId, ApplicationUser user);
    }
}
