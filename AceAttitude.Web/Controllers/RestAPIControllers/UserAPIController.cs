using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;

using AceAttitude.Services.Mapping;

using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly string InvalidUserCreationErrorMessage = "Unable to create user, invalid input data!";

        private readonly IModelMapper modelMapper;

        private readonly IUserService userService;
        private readonly IAuthService authService;

        public UserController(IUserService userService, IAuthService authService, IModelMapper modelMapper)
        {
            this.userService = userService;
            this.authService = authService;
            this.modelMapper = modelMapper;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserRegisterRequestDTO userDTO)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidUserCreationErrorMessage);
                }

                ApplicationUser user = authService.ValidateUserCanRegister(userDTO);

                UserResponseDTO userResponseDTO = modelMapper.MapToResponseUserDTO(userService.Create(user));

                return StatusCode(StatusCodes.Status201Created, userResponseDTO);
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateUser(ApplicationUser user)
        {
            var createdUser = userService.Create(user);
            return StatusCode(StatusCodes.Status201Created, createdUser);
        }

        [HttpPut("{id}/edit")]
        public IActionResult UpdateUser(int id, [FromBody] ApplicationUser user)
        {
            var updatedUser = userService.Update(id, user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var deletedUser = userService.Delete(id);
            return Ok(deletedUser);
        }
    }
}