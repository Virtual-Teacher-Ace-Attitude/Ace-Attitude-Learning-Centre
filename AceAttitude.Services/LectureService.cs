using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;

namespace AceAttitude.Services
{
    public class LectureService : ILectureService
    {
        private const string StudentNotEnrolledErrorMessage = "You are not enrolled in this course!";
        private const string TeacherNotApprovedErrorMessage = "You are not an approved teacher!";

        private readonly IModelMapper modelMapper;

        private readonly IUserRepository userRepository;
        private readonly ILectureRepository lectureRepository;

        public LectureService(ILectureRepository lectureRepository, IUserRepository userRepository, IModelMapper modelMapper)
        {
            this.lectureRepository = lectureRepository;
            this.userRepository = userRepository;
            this.modelMapper = modelMapper;
        }
        public Lecture CreateLecture(Lecture lecture, Course course, ApplicationUser user)
        {
            //User must be a teacher and course creator!
             return lectureRepository.CreateLecture(lecture, course);
        }

        public Lecture DeleteLecture(int lectureId, int courseId, ApplicationUser user)
        {
            //User must be a teacher and course creator!
            return lectureRepository.DeleteLecture(lectureId, courseId);
        }


        public Lecture GetById(int lectureId, int courseId, ApplicationUser user)
        {
            //Must be enrolled in the course OR teacher
            string userType = this.ReturnUserType(user);

            if (userType == "student")
            {
                this.EnsureStudentEnrolled(user, courseId);
            }
            else if (userType == "teacher")
            {
                this.EnsureTeacherApproved(user);
            }

            return lectureRepository.GetById(lectureId, courseId);
        }

        public Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture, ApplicationUser user)
        {
            //User must be a teacher and course creator!
            return lectureRepository.UpdateLecture(lectureId, courseId, lecture);
        }

        private void EnsureStudentEnrolled(ApplicationUser user, int courseId)
        {
            Student student = this.userRepository.GetStudentById(user.Id);

            if (!student.StudentCourses.Any(sc => sc.CourseId == courseId)) 
            {
                throw new UnauthorizedOperationException(StudentNotEnrolledErrorMessage);
            }
        }

        private void EnsureTeacherApproved(ApplicationUser user)
        {
            Teacher teacher = this.userRepository.GetTeacherById(user.Id);

            if (teacher.IsApproved == false)
            {
                throw new UnauthorizedOperationException(TeacherNotApprovedErrorMessage);
            }
        }

        private string ReturnUserType(ApplicationUser user)
        {
            if (user.TeacherId is null)
            {
                return "student";
            }
            else
            {
                return "teacher";
            }
        }
    }
}
