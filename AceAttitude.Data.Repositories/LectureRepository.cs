using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;
using Microsoft.EntityFrameworkCore;

namespace AceAttitude.Data.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly string LectureDoesntBelongToCourseErrorMessage = "Lecture with id: {0} is not associated to course with id: {1}.";
        private readonly string LectureDoesntExistErrorMessage = "A lecture with id: {0} does not exist.";

        private readonly ApplicationDbContext lectureContext;

        public LectureRepository(ApplicationDbContext lectureContext)
        {
            this.lectureContext = lectureContext;
        }
        public Lecture CreateLecture(Lecture lecture, int courseId)
        {
            lecture.CreatedOn = DateTime.Now;

            lectureContext.Lectures.Add(lecture);

            lectureContext.SaveChanges();

            return this.GetById(lecture.Id, courseId);
        }

        public Lecture DeleteLecture(int lectureId, int courseId)
        {
            Lecture lectureToDelete = GetById(lectureId, courseId);

            lectureToDelete.DeletedOn = DateTime.Now;

            lectureContext.SaveChanges();

            return lectureToDelete;
        }

        public Lecture GetById(int lectureId, int courseId)
        {
            Lecture lecture = lectureContext.Lectures
                .Include(lecture => lecture.Course)
                .FirstOrDefault(l => l.Id == lectureId && l.DeletedOn.HasValue == false)
                ?? throw new EntityNotFoundException(string.Format(LectureDoesntExistErrorMessage, lectureId));

            this.EnsureLectureBelongsToCourse(lecture, courseId);

            return lecture;
        }

        public Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture)
        {
            Lecture lectureToUpdate = GetById(lectureId, courseId);

            lectureToUpdate.Title = lecture.Title;
            lectureToUpdate.Description = lecture.Description;
            lectureToUpdate.VideoFilePath = lecture.VideoFilePath;
            lectureToUpdate.TextFilePath = lecture.TextFilePath;
            lectureToUpdate.ModifiedOn = DateTime.Now;

            lectureContext.SaveChanges();

            return lectureToUpdate;
        }

        private void EnsureLectureBelongsToCourse(Lecture lecture, int courseId)
        {
            if (lecture.CourseId != courseId)
            {
                throw new UnauthorizedOperationException(string.Format(LectureDoesntBelongToCourseErrorMessage, lecture.Id, courseId));
            }
        }
    }
}
