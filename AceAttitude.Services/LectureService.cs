

using AceAttitude.Data.Models.Contracts;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;

namespace AceAttitude.Services
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository lectureRepository;
        public LectureService(ILectureRepository lectureRepository) 
        {
            this.lectureRepository = lectureRepository;
        }
        public ILecture CreateLecture(ILecture lecture, IApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public ILecture DeleteLecture(int id, IApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public ILecture GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ILecture UpdateLecture(int id, ILecture lecture, IApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
