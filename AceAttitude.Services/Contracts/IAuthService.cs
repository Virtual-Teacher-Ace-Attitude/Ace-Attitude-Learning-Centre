using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services.Contracts
{
    public interface IAuthService
    {
        //User CurrentUser { get; }
        ApplicationUser TryGetUser(string credentials);
        ApplicationUser ValidateUserCanRegister(UserRegisterRequestDTO userDTO);

        //ApplicationUser LoginUser(UserRegisterDTO userDTO);

        string GeneratePasswordHash(string password);

        //void EnsureUserAdmin();

        //public void Logout();

        //public void Login(string username, string password);

        //public bool EnsureUserLoggedIn();
    }
}
