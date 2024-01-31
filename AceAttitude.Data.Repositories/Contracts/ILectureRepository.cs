using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Contracts;


namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ILectureRepository
    {
        public Lecture GetById(int id);

        public Lecture CreateLecture (Lecture lecture);

        public Lecture UpdateLecture (Lecture lecture);

        public Lecture DeleteLecture (int id);
    }
}
