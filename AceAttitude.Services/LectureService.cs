

using AceAttitude.Data.Models;
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
        public Lecture CreateLecture(Lecture lecture, Course course, ApplicationUser user)
        {
            //User must be a teacher and course creator!
             return lectureRepository.CreateLecture(lecture, course);
        }

        public Lecture DeleteLecture(int id, ApplicationUser user)
        {
            //User must be a teacher and course creator!
            return lectureRepository.DeleteLecture(id);
        }

        public Lecture GetById(int id)
        {
            //Must be registered!
            return lectureRepository.GetById(id);
        }

        public Lecture UpdateLecture(int id, Lecture lecture, ApplicationUser user)
        {
            //User must be a teacher and course creator!
            return lectureRepository.UpdateLecture(id, lecture);
        }
    }
}
