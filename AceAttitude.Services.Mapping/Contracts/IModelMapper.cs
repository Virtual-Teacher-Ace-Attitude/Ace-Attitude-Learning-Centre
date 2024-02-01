using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;

namespace AceAttitude.Services.Mapping.Contracts
{
    public interface IModelMapper
    {
        public ApplicationUser MapToUser(UserRegisterRequestDTO userDTO, string passwordHash);

        public UserResponseDTO MapToResponseUserDTO(ApplicationUser user);
    }
}
