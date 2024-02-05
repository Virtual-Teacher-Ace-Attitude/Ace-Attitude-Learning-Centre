using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
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
        public IActionResult GetUserById(string id)
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

                UserResponseDTO userResponseDto = modelMapper.MapToResponseUserDTO(userService.CreateStudent(user), "Student");

                return StatusCode(StatusCodes.Status201Created, userResponseDto);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost("Register/Teacher")]
        public IActionResult RegisterTeacher([FromBody] UserRegisterRequestDTO userDTO)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidUserCreationErrorMessage);
                }

                ApplicationUser user = authService.ValidateUserCanRegister(userDTO);

                UserResponseDTO teacherResponseDto = modelMapper.MapToResponseUserDTO(userService.CreateTeacher(user), "Teacher - Awaiting Approval");

                return StatusCode(StatusCodes.Status201Created, teacherResponseDto);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        //[HttpPost("")]
        //public IActionResult CreateUser(ApplicationUser user)
        //{
        //    var createdUser = userService.Create(user);
        //    return StatusCode(StatusCodes.Status201Created, createdUser);
        //}

        [HttpPut("{id}/Edit")]
        public IActionResult UpdateUser(string id, [FromBody] ApplicationUser user)
        {
            var updatedUser = userService.Update(id, user);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(string id)
        {
            var deletedUser = userService.Delete(id);
            return Ok(deletedUser);
        }
    }
}