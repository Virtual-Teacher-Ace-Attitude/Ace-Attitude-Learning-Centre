using AceAttitude.Data.Models;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services.Mapping
{
    public class ModelMapper : IModelMapper
    {
        public ApplicationUser MapToUser(UserRegisterRequestDTO userDTO, string passwordHash)
        {
            return new ApplicationUser
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                PasswordHash = passwordHash,
                CreatedOn = DateTime.Now
            };
        }
    }
}
