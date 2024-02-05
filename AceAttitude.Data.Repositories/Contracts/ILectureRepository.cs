using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ILectureRepository
    {
        public Lecture GetById(int lectureId, int courseId);

        public Lecture CreateLecture(LectureRequestDTO lectureRequestDTO, Course course);

        public Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture);

        public Lecture DeleteLecture(int lectureId, int courseId);
    }
}
