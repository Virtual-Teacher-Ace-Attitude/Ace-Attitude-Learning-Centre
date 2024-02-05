using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services.Contracts
{
    public interface ILectureService
    {
        Lecture GetById(int lectureId, int courseId, ApplicationUser user);

        Lecture CreateLecture(LectureRequestDTO lecture, int courseId, Teacher teacher);

        Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture, ApplicationUser user);

        Lecture DeleteLecture(int lectureId, int courseId, ApplicationUser user);
    }
}
