using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services
{
    public class AuthService : IAuthService
    {
        private readonly string IncorrectCredentialsErrorMessage = "The username or password provided are incorrect!";

        private readonly string NotStudentErrorMessage = "The following action can only be performed by a student!";
        private readonly string NotTeacherErrorMessage = "The following action can only be performed by a teacher!";

        private readonly IModelMapper modelMapper;
        private readonly IUserService userService;

        public AuthService(IModelMapper modelMapper, IUserService userService)
        {
            this.modelMapper = modelMapper;
            this.userService = userService;
        }

        public ApplicationUser ValidateUserCanRegister(UserRegisterRequestDTO userDTO, UserType userType)
        {
            this.userService.CheckEmailExists(userDTO.Email);

            string passwordHash = this.GeneratePasswordHash(userDTO.Password);

            ApplicationUser user = this.modelMapper.MapToUser(userDTO, passwordHash);
            user.UserType = userType;

            return user;
        }

        public ApplicationUser TryGetUser(string credentials)
        {
            try
            {
                string[] splitCredentials = credentials.Split('|');
                string email = splitCredentials[0];
                string password = splitCredentials[1];

                ApplicationUser user = userService.GetByEmail(email);

                if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    throw new UnauthorizedOperationException(IncorrectCredentialsErrorMessage);
                }

                return user;
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException(IncorrectCredentialsErrorMessage);
            }
        }

        public Student TryGetStudent(string credentials)
        {
            ApplicationUser user = this.TryGetUser(credentials);

            if (user.StudentId is null)
            {
                throw new UnauthorizedOperationException(NotStudentErrorMessage);
            }

            return this.userService.GetStudentById(user.StudentId);
        }

        public Teacher TryGetTeacher(string credentials)
        {
            ApplicationUser user = this.TryGetUser(credentials);

            if (user.TeacherId is null)
            {
                throw new UnauthorizedOperationException(NotTeacherErrorMessage);
            }

            return this.userService.GetTeacherById(user.TeacherId);
        }

        public string GeneratePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
