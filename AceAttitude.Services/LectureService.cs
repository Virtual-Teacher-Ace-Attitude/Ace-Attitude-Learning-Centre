using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;

namespace AceAttitude.Services
{
    public class LectureService : ILectureService
    {

        private readonly IAuthHelper authHelper;
        private readonly IUserRepository userRepository;
        private readonly ILectureRepository lectureRepository;

        public LectureService(ILectureRepository lectureRepository, IUserRepository userRepository, IAuthHelper authHelper)
        {
            this.lectureRepository = lectureRepository;
            this.userRepository = userRepository;
            this.authHelper = authHelper;
        }
        public Lecture CreateLecture(Lecture lecture, int courseId, Teacher teacher)
        {
            //User must be a teacher and course creator!


            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreatorOrAdmin(teacher, courseId);

            return lectureRepository.CreateLecture(lecture, courseId);
        }

        public Lecture DeleteLecture(int lectureId, int courseId, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreatorOrAdmin(teacher, courseId);
            return lectureRepository.DeleteLecture(lectureId, courseId);
        }


        public Lecture GetById(int lectureId, int courseId, ApplicationUser user)
        {
            //Must be enrolled in the course OR teacher
            if (user.UserType == UserType.Student)
            {
                Student student = this.userRepository.GetStudentById(user.Id);
                authHelper.EnsureStudentEnrolled(student, courseId);
            }
            else if (user.UserType == UserType.Teacher)
            {
                Teacher teacher = this.userRepository.GetTeacherById(user.Id);
                authHelper.EnsureTeacherApproved(teacher);
            }

            return lectureRepository.GetById(lectureId, courseId);
        }

        public Lecture UpdateLecture(int lectureId, int courseId, Lecture lecture, Teacher teacher)
        {
            authHelper.EnsureTeacherApproved(teacher);
            authHelper.EnsureTeacherIsCourseCreatorOrAdmin(teacher, courseId);
            return lectureRepository.UpdateLecture(lectureId, courseId, lecture);
        }

    }
}
