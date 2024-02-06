using AceAttitude.Data.Models;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;
using AceAttitude.Web.DTO.Request;
using Helpers;

namespace AceAttitude.Services
{
    public class LectureService : ILectureService
    {

        private readonly AuthHelper authHelper;
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

            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreator(teacher, courseId);

            return lectureRepository.CreateLecture(lectureRequestDTO, course);
        }

        public Lecture DeleteLecture(int lectureId, int courseId, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreator(teacher, courseId);
            return lectureRepository.DeleteLecture(lectureId, courseId);
        }


        public Lecture GetById(int lectureId, int courseId, ApplicationUser user)
        {
            //Must be enrolled in the course OR teacher
            string userType = authHelper.ReturnUserType(user);

            if (userType == "student")
            {
                Student student = this.userRepository.GetStudentById(user.Id);
                authHelper.EnsureStudentEnrolled(student, courseId);
            }
            else if (userType == "teacher")
            {
                Teacher teacher = this.userRepository.GetTeacherById(user.Id);
                authHelper.EnsureTeacherApproved(teacher);
            }

            return lectureRepository.GetById(lectureId, courseId);
        }

        public Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreator(teacher, courseId);
            return lectureRepository.UpdateLecture(lectureId, courseId, lecture);
        }


    }
}
