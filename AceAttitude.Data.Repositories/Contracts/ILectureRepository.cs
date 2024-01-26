using AceAttitude.Data.Models.Contracts;


namespace AceAttitude.Data.Repositories.Contracts
{
    public interface ILectureRepository
    {
        public ILecture GetById(int id);

        public ILecture CreateLecture (ILecture lecture);

        public ILecture UpdateLecture (ILecture lecture);

        public ILecture DeleteLecture (int id);
    }
}
