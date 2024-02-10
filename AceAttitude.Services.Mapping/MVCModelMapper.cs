using AceAttitude.Data.Models;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.ViewModels;

namespace AceAttitude.Services.Mapping
{
    public class MVCModelMapper : IMVCModelMapper
    {
        public ApplicationUser MapToUser(RegisterViewModel registerViewModel, string passwordHash)
        {
            return new ApplicationUser
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                PasswordHash = passwordHash,
                CreatedOn = DateTime.Now,
            };
        }
    }
}
