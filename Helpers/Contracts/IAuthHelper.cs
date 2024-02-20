using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;

namespace AceAttitude.Common.Helpers.Contracts
{
    public interface IAuthHelper
    {
        public void EnsureIdMatching(string id, ApplicationUser requestUser, string message);

        public void EnsureTeacherIsCourseCreatorOrAdmin(Teacher teacher, int courseId);

        public void EnsureTeacherIsCourseCreator(Teacher teacher, int courseId);

        public void EnsureStudentEnrolled(Student student, int courseId);

        public void EnsureTeacherApproved(Teacher teacher);

        public void EnsureIdMatchingOrAdmin(string id, ApplicationUser requestUser, string message);
    }
}
