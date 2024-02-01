

using AceAttitude.Data.Models;
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
        public Lecture CreateLecture(Lecture lecture, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Lecture DeleteLecture(int id, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Lecture GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Lecture UpdateLecture(int id, Lecture lecture, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
