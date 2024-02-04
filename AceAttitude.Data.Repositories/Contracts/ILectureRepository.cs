using AceAttitude.Data.Models;


namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ILectureRepository
    {
        public Lecture GetById(int lectureId, int courseId);

        public Lecture CreateLecture(Lecture lecture, Course course);

        public Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture);

        public Lecture DeleteLecture(int lectureId, int courseId);
    }
}
