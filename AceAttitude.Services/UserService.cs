using AceAttitude.Common.Exceptions;
using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services
{
    public class UserService : IUserService
    {
        private readonly string DuplicateEmailRegisterErrorMessage = "The email provided is already registered under an existing account!";
        private readonly string AdminRequiredErrorMessage = "This operation can only be performed by an admin!";

        private readonly string UnableToViewProfileErrorMessage = "Only the creator of the profile or an admin can view it!";
        private readonly string UnableToEditProfileErrorMessage = "Only the creator of the profile or an admin can edit it!";

        private readonly string InvalidUserTypeErrorMessage = "This action can only be performed by a {0} or admin!";
        private readonly string StudentRequiredForApplicationErrorMessage = "You are already a teacher!";

        private readonly IUserRepository userRepository;
        private readonly IAuthHelper authHelper;

        public UserService(IUserRepository userRepository, IAuthHelper authHelper)
        {
            this.userRepository = userRepository;
            this.authHelper = authHelper;
        }

        public ApplicationUser GetById(string id)
        {
            return this.userRepository.GetById(id);
        }

        public ApplicationUser GetByEmail(string email)
        {
            return this.userRepository.GetByEmail(email);
        }

        public Student GetStudentById(string id)
        {
            return this.userRepository.GetStudentById(id);
        }

        public Teacher GetTeacherById(string id)
        {
            return this.userRepository.GetTeacherById(id);
        }

        public ApplicationUser CreateStudent(ApplicationUser user)
        {
            return this.userRepository.CreateStudent(user);
        }

        public ApplicationUser CreateTeacher(ApplicationUser user)
        {
            return this.userRepository.CreateTeacher(user);
        }

        public ApplicationUser Create(ApplicationUser user)
        {
            return this.userRepository.Create(user); ;
        }

        public ApplicationUser Delete(string id, ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(AdminRequiredErrorMessage);
            }

            return this.userRepository.Delete(id);
        }

        public ApplicationUser Update(string id, ApplicationUser requestUser, ApplicationUser userToUpdate)
        {
            this.authHelper.EnsureIdMatchingOrAdmin(id, requestUser, UnableToEditProfileErrorMessage);

            return this.userRepository.Update(id, userToUpdate);
        }

        public void CheckEmailExists(string email)
        {
            if (this.userRepository.CheckEmailExists(email))
            {
                throw new DuplicateEntityException(DuplicateEmailRegisterErrorMessage);
            }
        }

        public ApplicationUser ViewUserProfile(string id, ApplicationUser requestUser)
        {
            this.authHelper.EnsureIdMatchingOrAdmin(id, requestUser, UnableToViewProfileErrorMessage);

            return this.userRepository.GetById(id);
        }

        public Teacher ViewTeacherProfile(string id, ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Teacher)
            {
                throw new UnauthorizedOperationException(string.Format(InvalidUserTypeErrorMessage, UserType.Teacher));
            }

            this.authHelper.EnsureIdMatchingOrAdmin(id, requestUser, UnableToViewProfileErrorMessage);

            return this.userRepository.GetTeacherById(id);
        }

        public Student ViewStudentProfile(string id, ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Student && requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(string.Format(InvalidUserTypeErrorMessage, UserType.Student));
            }

            this.authHelper.EnsureIdMatchingOrAdmin(id, requestUser, UnableToViewProfileErrorMessage);

            return this.userRepository.GetStudentById(id);
        }

        public Student ApplyForTeacher(ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Student)
            {
                throw new UnauthorizedOperationException(StudentRequiredForApplicationErrorMessage);
            }

            return this.userRepository.ApplyForTeacher(requestUser.Id);
        }

        public ICollection<Teacher> GetUnapprovedTeachers(ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(AdminRequiredErrorMessage);
            }

            return this.userRepository.GetUnapprovedTeachers();
        }

        public ICollection<Student> GetUnapprovedStudents(ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(AdminRequiredErrorMessage);
            }

            return this.userRepository.GetUnapprovedStudents();
        }

        public Teacher ApproveTeacher(string id, ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(AdminRequiredErrorMessage);
            }

            return this.userRepository.ApproveTeacher(id);
        }

        public Teacher PromoteStudent(string id, ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(AdminRequiredErrorMessage);
            }

            return this.userRepository.PromoteStudent(id);
        }

        public Teacher PromoteAdmin(string id, ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(AdminRequiredErrorMessage);
            }

            return this.userRepository.PromoteAdmin(id);
        }

        public string UpdateProfilePicturePath(string path, string userId)
        {
            return this.userRepository.UpdateProfilePicturePath(path, userId);
        }
    }
}
