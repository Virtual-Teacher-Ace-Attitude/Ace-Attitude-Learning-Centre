using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services
{
    public class LectureService : ILectureService
    {
        private const string StudentNotEnrolledErrorMessage = "You are not enrolled in this course!";
        private const string TeacherNotApprovedErrorMessage = "You are not an approved teacher!";
        private const string TeacherNotCourseCreator = "You are not the creator of this course!";

        private readonly IUserRepository userRepository;
        private readonly ILectureRepository lectureRepository;
        private readonly ICourseRepository courseRepository;

        public LectureService(ILectureRepository lectureRepository, IUserRepository userRepository, ICourseRepository courseRepository)
        {
            this.lectureRepository = lectureRepository;
            this.userRepository = userRepository;
            this.courseRepository = courseRepository;
        }
        public Lecture CreateLecture(LectureRequestDTO lectureRequestDTO, int courseId, Teacher teacher)
        {
            //User must be a teacher and course creator!

            Course course = this.courseRepository.GetById(courseId);

            this.EnsureTeacherApproved(teacher);
            this.EnsureTeacherIsCourseCreator(teacher, courseId);

            return lectureRepository.CreateLecture(lectureRequestDTO, course);
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
                Student student = this.userRepository.GetStudentById(user.Id);
                this.EnsureStudentEnrolled(student, courseId);
            }
            else if (userType == "teacher")
            {
                Teacher teacher = this.userRepository.GetTeacherById(user.Id);
                this.EnsureTeacherApproved(teacher);
            }

            return lectureRepository.GetById(lectureId, courseId);
        }

        public Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture, ApplicationUser user)
        {
            //User must be a teacher and course creator!
            return lectureRepository.UpdateLecture(lectureId, courseId, lecture);
        }

        private void EnsureTeacherIsCourseCreator(Teacher teacher, int courseId)
        {
            if (!teacher.CreatedCourses.Any(cc => cc.Id == courseId))
            {
                throw new UnauthorizedOperationException(TeacherNotCourseCreator);
            }
        }

        private void EnsureStudentEnrolled(Student student, int courseId)
        {
            if (!student.StudentCourses.Any(sc => sc.CourseId == courseId)) 
            {
                throw new UnauthorizedOperationException(StudentNotEnrolledErrorMessage);
            }
        }

        private void EnsureTeacherApproved(Teacher teacher)
        {
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
