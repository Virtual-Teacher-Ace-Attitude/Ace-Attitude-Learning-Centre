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
    [Route("api/courses/{courseId}/lectures")]
    public class LectureAPIController : ControllerBase
    {
        private readonly string InvalidLectureCreationErrorMessage = "Unable to create lecture, invalid input data!";

        private readonly IAuthService authService;
        private readonly IModelMapper modelMapper;

        private readonly IUserService userService;
        private readonly ILectureService lectureService;
        private readonly ICourseService courseService;

        public LectureAPIController(ILectureService lectureService, IUserService userService, ICourseService courseService, 
            IAuthService authService, IModelMapper modelMapper)
        {
            this.lectureService = lectureService;
            this.userService = userService;
            this.courseService = courseService;

            this.authService = authService;
            this.modelMapper = modelMapper;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.

        [HttpGet("{lectureId}")]
        public IActionResult GetLectureById([FromHeader] string credentials, int lectureId, [FromRoute] string courseId)
        {
            // Needs a DTO and model validation

            try
            {
                int parsedCourseId = this.ParseId(courseId);

                ApplicationUser user = this.authService.TryGetUser(credentials);

                return Ok(lectureService.GetById(lectureId, parsedCourseId, user));
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateLecture([FromHeader] string credentials, [FromBody] LectureRequestDTO lectureRequestDTO, [FromRoute] int courseId)
        {
            // Needs a DTO and model validation
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidLectureCreationErrorMessage);
                }

                Teacher teacher = authService.TryGetTeacher(credentials);

                Lecture createdLecture = lectureService.CreateLecture(lectureRequestDTO, courseId, teacher);

                LectureResponseDTO responseDTO = this.modelMapper.MapToLectureResponseDTO(createdLecture);

                return StatusCode(StatusCodes.Status201Created, responseDTO);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLecture([FromHeader] string credentials, int lectureId, [FromBody] Lecture lecture, [FromHeader] string userId, [FromQuery] int courseId)
        {
            var user = userService.GetById(userId);
            var updatedLecture = lectureService.UpdateLecture(lectureId, courseId,lecture, user);
            return Ok(updatedLecture);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLecture([FromHeader] string credentials, int id, [FromHeader] string userId, [FromQuery] int courseId)
        {
            var user = userService.GetById(userId);
            var deletedLecture = lectureService.DeleteLecture(id, courseId, user);
            return Ok(deletedLecture);
        }

        private int ParseId(string paramValue)
        {
            if (int.TryParse(paramValue, out int id))
            {
                return id;
            }
            else
            {
                throw new InvalidUserInputException("Id must be an integer number.");
            }
        }
    }
}
