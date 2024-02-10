using AceAttitude.Data.Models;
using AceAttitude.Web.ViewModels;

namespace AceAttitude.Services.Mapping.Contracts
{
    public interface IMVCModelMapper
    {
        public ApplicationUser MapToUser(RegisterViewModel registerViewModel, string passwordHash);
    }
}
