using AceAttitude.Data.Models;


namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ILectureRepository
    {
        public Lecture GetById(int id);

        public Lecture CreateLecture(Lecture lecture, Course course);

        public Lecture UpdateLecture(int id, Lecture lecture);

        public Lecture DeleteLecture(int id);
    }
}
