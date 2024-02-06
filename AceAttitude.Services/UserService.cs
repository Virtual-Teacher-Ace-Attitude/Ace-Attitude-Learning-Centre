using AceAttitude.Common.Exceptions;
using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services.Contracts;

namespace AceAttitude.Services
{
    public class UserService : IUserService
    {
        private readonly string DuplicateEmailRegisterErrorMessage = "The email provided is already registered under an existing account!";
        private readonly string AdminRequiredErrorMessage = "This operation can only be performed by an admin!";

        private readonly IUserRepository userRepository;
        private readonly IAuthHelper authHelper;

        public UserService(IUserRepository userRepository, IAuthHelper authHelper)
        {
            this.userRepository = userRepository;
            this.authHelper = authHelper;
        }

        public ApplicationUser GetById(string id)
        {
            throw new NotImplementedException();
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

        public ApplicationUser Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser Update(string id, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void CheckEmailExists(string email)
        {
            if (this.userRepository.CheckEmailExists(email))
            {
                throw new DuplicateEntityException(DuplicateEmailRegisterErrorMessage);
            }
        }

        public Teacher ViewTeacherProfile(string id, ApplicationUser requestUser)
        {
            this.authHelper.EnsureIdMatchingOrAdmin(id, requestUser);

            return this.userRepository.GetTeacherById(id);
        }

        public Student ViewStudentProfile(string id, ApplicationUser requestUser)
        {
            this.authHelper.EnsureIdMatchingOrAdmin(id, requestUser);

            return this.userRepository.GetStudentById(id);
        }

        public ICollection<Teacher> GetUnapprovedTeachers(ApplicationUser requestUser)
        {
            if (requestUser.UserType != UserType.Admin)
            {
                throw new UnauthorizedOperationException(AdminRequiredErrorMessage);
            }

            return this.userRepository.GetUnapprovedTeachers();
        }
    }
}
