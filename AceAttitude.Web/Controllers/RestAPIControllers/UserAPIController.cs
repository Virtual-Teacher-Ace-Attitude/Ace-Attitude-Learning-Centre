using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
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

        [HttpPost("Register/Student")]
        public IActionResult RegisterStudent([FromBody] UserRegisterRequestDTO userDTO)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidUserCreationErrorMessage);
                }

                ApplicationUser user = authService.ValidateUserCanRegister(userDTO, UserType.Student);

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

                ApplicationUser user = authService.ValidateUserCanRegister(userDTO, UserType.Teacher);

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

        // Author required
        [HttpGet("{id}/teachers/profile")]
        public IActionResult ViewTeacherProfile([FromHeader] string credentials, string id)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                Teacher teacherToView = this.userService.ViewTeacherProfile(id, user);

                TeacherResponseDTO teacherResponseDto = this.modelMapper.MapToTeacherResponseDTO(teacherToView);

                return StatusCode(StatusCodes.Status200OK, teacherResponseDto);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("{id}/students/profile")]
        public IActionResult ViewStudentProfile([FromHeader] string credentials, string id)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                Student studentToView = this.userService.ViewStudentProfile(id, user);

                StudentResponseDTO studentResponseDTO = this.modelMapper.MapToStudentResponseDTO(studentToView);

                return StatusCode(StatusCodes.Status200OK, studentResponseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("teachers/unapproved")]
        public IActionResult ViewUnapprovedTeachers([FromHeader] string credentials)
        {

            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                ICollection<Teacher> unapprovedTeachers = this.userService.GetUnapprovedTeachers(user);

                ICollection<TeacherResponseDTO> teachersAsDTO = unapprovedTeachers.Select(this.modelMapper.MapToTeacherResponseDTO).ToList();

                return StatusCode(StatusCodes.Status200OK, teachersAsDTO);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
        }
    }
}