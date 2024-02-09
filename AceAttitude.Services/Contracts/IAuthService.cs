using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services.Contracts
{
    public interface IAuthService
    {
        public ApplicationUser TryGetUser(string credentials);

        public Student TryGetStudent(string credentials);

        public Teacher TryGetTeacher(string credentials);

        public ApplicationUser ValidateUserCanRegister(UserRegisterRequestDTO userDTO, UserType userType);

        public string GeneratePasswordHash(string password);

        // Front-End auth methods
        public ApplicationUser CurrentUser { get; }

        public void EnsureUserAdmin();

        public void Logout();

        public void Login(string username, string password);

        public bool EnsureUserLoggedIn();
    }
}
