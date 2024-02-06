using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;

namespace Helpers
{
    public class AuthHelper
    {
        private const string StudentNotEnrolledErrorMessage = "You are not enrolled in this course!";
        private const string TeacherNotApprovedErrorMessage = "You are not an approved teacher!";
        private const string TeacherNotCourseCreator = "You are not the creator of this course!";
        public void EnsureTeacherIsCourseCreatorOrAdmin(Teacher teacher, int courseId)
        {
            if (!teacher.CreatedCourses.Any(cc => cc.Id == courseId) && teacher.IsAdmin == false)
            {
                throw new UnauthorizedOperationException(TeacherNotCourseCreator);
            }
        }

        public void EnsureStudentEnrolled(Student student, int courseId)
        {
            if (!student.StudentCourses.Any(sc => sc.CourseId == courseId))
            {
                throw new UnauthorizedOperationException(StudentNotEnrolledErrorMessage);
            }
        }

        public void EnsureTeacherApproved(Teacher teacher)
        {
            if (teacher.IsApproved == false)
            {
                throw new UnauthorizedOperationException(TeacherNotApprovedErrorMessage);
            }
        }

        public string ReturnUserType(ApplicationUser user)
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