﻿using AceAttitude.Common.Exceptions;
using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Common.Helpers
{
    public class AuthHelper : IAuthHelper
    {
        private const string StudentNotEnrolledErrorMessage = "You are not enrolled in this course!";
        private const string TeacherNotApprovedErrorMessage = "You are not an approved teacher!";
        private const string TeacherNotCourseCreator = "You are not the creator of this course!";

        private readonly string UnableToViewProfileErrorMessage = "Only the creator of the profile or an admin can view it!";

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

        public void EnsureIdMatchingOrAdmin(string id, ApplicationUser requestUser)
        {
            if (requestUser.Id != id && requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(UnableToViewProfileErrorMessage);
            }
        }
    }
}