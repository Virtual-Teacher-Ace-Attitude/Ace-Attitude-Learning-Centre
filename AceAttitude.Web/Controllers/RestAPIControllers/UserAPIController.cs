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

        [HttpPost("register/student")]
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

        [HttpPost("register/teacher")]
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
        [HttpGet("teachers/{id}")]
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

        [HttpGet("students/{id}")]
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

        [HttpPut("student/{id}/apply/")]
        public IActionResult ApplyForTeacher([FromHeader] string credentials, string id)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                Student student = this.userService.ApplyForTeacher(id, user);

                StudentResponseDTO studentResponseDTO = this.modelMapper.MapToStudentResponseDTO(student);

                return StatusCode(StatusCodes.Status200OK, studentResponseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e);
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

        [HttpGet("students/unapproved")]
        public IActionResult ViewUnapprovedStudents([FromHeader] string credentials)
        {

            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                ICollection<Student> unapprovedStudents = this.userService.GetUnapprovedStudents(user);

                ICollection<StudentResponseDTO> studentsAsDTO = unapprovedStudents.Select(this.modelMapper.MapToStudentResponseDTO).ToList();

                return StatusCode(StatusCodes.Status200OK, studentsAsDTO);
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

        [HttpPut("teachers/approve/{id}")]
        public IActionResult ApproveTeacher([FromHeader] string credentials, string id)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                Teacher teacher = this.userService.ApproveTeacher(id, user);

                TeacherResponseDTO teacherResponseDTO = this.modelMapper.MapToTeacherResponseDTO(teacher);

                return StatusCode(StatusCodes.Status200OK, teacherResponseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("students/promote/{id}")]
        public IActionResult PromoteStudent([FromHeader] string credentials, string id)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                Teacher teacher = this.userService.PromoteStudent(id, user);

                TeacherResponseDTO teacherResponseDTO = this.modelMapper.MapToTeacherResponseDTO(teacher);

                return StatusCode(StatusCodes.Status200OK, teacherResponseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("teachers/promote/{id}")]
        public IActionResult PromoteAdmin([FromHeader] string credentials, string id)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                Teacher teacher = this.userService.PromoteAdmin(id, user);

                TeacherResponseDTO teacherResponseDTO = this.modelMapper.MapToTeacherResponseDTO(teacher);

                return StatusCode(StatusCodes.Status200OK, teacherResponseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromHeader] string credentials, string id)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                ApplicationUser deletedUser = this.userService.Delete(id, user);

                UserResponseDTO userResponseDto = this.modelMapper.MapToResponseUserDTO(deletedUser, deletedUser.UserType.ToString());

                return StatusCode(StatusCodes.Status200OK, userResponseDto);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromHeader] string credentials, string id, [FromBody] UserUpdateRequestDTO userUpdateRequestDTO)
        {
            try
            {
                ApplicationUser user = this.authService.TryGetUser(credentials);

                string passwordHash = this.authService.GeneratePasswordHash(userUpdateRequestDTO.Password);
                userUpdateRequestDTO.Password = passwordHash;

                ApplicationUser userToUpdate = this.modelMapper.MapToUser(userUpdateRequestDTO);

                ApplicationUser updatedUser = this.userService.Update(id, user, userToUpdate);

                UserResponseDTO userResponseDto = this.modelMapper.MapToResponseUserDTO(updatedUser, updatedUser.UserType.ToString());

                return StatusCode(StatusCodes.Status200OK, userResponseDto);
            }
            catch (EntityNotFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Conflict(e.Message);
            }
        }
    }
}