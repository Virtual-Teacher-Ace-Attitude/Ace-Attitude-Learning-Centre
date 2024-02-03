using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.

        [HttpGet("{id}")]
        public IActionResult GetLectureById(int id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpPost("Register/Student")]
        public IActionResult RegisterStudent([FromBody] UserRegisterRequestDTO userDTO)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidUserCreationErrorMessage);
                }

                ApplicationUser user = authService.ValidateUserCanRegister(userDTO);



                Student student = this.modelMapper.MapToStudent(user);

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
            var createdUser = userService.CreateUser(user);
            return StatusCode(StatusCodes.Status201Created, createdUser);
        }

        [HttpPut("{id}/edit")]
        public IActionResult UpdateUser(int id, [FromBody] ApplicationUser user)
        {
            var updatedUser = userService.UpdateUser(id, user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var deletedUser = userService.DeleteUser(id);
            return Ok(deletedUser);
        }
    }
}