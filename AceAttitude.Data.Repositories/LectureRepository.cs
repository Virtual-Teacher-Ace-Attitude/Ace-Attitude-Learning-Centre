using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;

namespace AceAttitude.Data.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly ApplicationDbContext lectureContext;
        public LectureRepository(ApplicationDbContext lectureContext)
        {
            this.lectureContext = lectureContext;
        }
        public Lecture CreateLecture(Lecture lecture, Course course)
        {
            lecture.Course = course;
            lecture.CreatedOn = DateTime.Now;
            lectureContext.Lectures.Add(lecture);
            lectureContext.SaveChanges();
            return lecture;
        }

        public Lecture DeleteLecture(int id)
        {
            Lecture lectureToDelete = GetById(id);
            lectureToDelete.DeletedOn = DateTime.Now;
            lectureContext.SaveChanges();
            return lectureToDelete;
        }

        public Lecture GetById(int id)
        {
            Lecture lecture = lectureContext.Lectures.FirstOrDefault(l => l.Id == id && l.IsDeleted == false)
                ?? throw new EntityNotFoundException($"A lecture with id: {id} does not exist.");
            return lecture;
        }

        public Lecture UpdateLecture(int id, Lecture lecture)
        {
            Lecture lectureToUpdate = GetById(id);

            lectureToUpdate.Title = lecture.Title;
            lectureToUpdate.Description = lecture.Description;
            lectureToUpdate.VideoFilePath = lecture.VideoFilePath;
            lectureToUpdate.TextFilePath = lecture.TextFilePath;
            lectureToUpdate.ModifiedOn = DateTime.Now;
            lectureContext.SaveChanges();

            return lectureToUpdate;
        }
    }
}
