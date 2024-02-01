using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services.Mapping.Contracts
{
    public interface IModelMapper
    {
        public ApplicationUser MapToUser(UserRegisterRequestDTO userDTO, string passwordHash);
    }
}
