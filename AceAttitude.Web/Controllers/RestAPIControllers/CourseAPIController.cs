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
    [Route("api/courses")]
    public class CourseAPIController : ControllerBase
    {
        private const string InvalidCourseCreationErrorMessage = "Unable to create course, invalid input data!";

        private readonly ICourseService courseService;
        private readonly IAuthService authService;
        private readonly IAPIModelMapper modelMapper;

        public CourseAPIController(ICourseService courseService, IAuthService authService, IAPIModelMapper modelMapper)
        {
            this.courseService = courseService;
            this.authService = authService;
            this.modelMapper = modelMapper;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.
        [HttpGet("")]
        public IActionResult GetAll([FromQuery] string filterParam,
            [FromQuery] string filterParamValue, [FromQuery] string sortParam)
        {
            try
            {
                List<CourseResponseDTO> courses = courseService.GetAll(filterParam, filterParamValue, sortParam)
                    .Select(course => modelMapper.MapToCourseResponseDTO(course))
                    .ToList();
                return Ok(courses);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            try
            {
                var course = courseService.GetById(id); 
                var responseDTO = modelMapper.MapToCourseResponseDTO(course);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateCourse(CourseRequestDTO courseRequestDTO, [FromHeader] string credentials)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidCourseCreationErrorMessage);
                }

                Teacher teacher = authService.TryGetTeacher(credentials);
                Course course = modelMapper.MapToCourse(courseRequestDTO);
                course.TeacherId = teacher.Id;
                Course createdCourse = courseService.CreateCourse(course, teacher);
                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(createdCourse);
                return StatusCode(StatusCodes.Status201Created, responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseRequestDTO courseRequestDTO, [FromHeader] string credentials)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidCourseCreationErrorMessage);
                }

                Teacher teacher = authService.TryGetTeacher(credentials);
                Course course = modelMapper.MapToCourse(courseRequestDTO);
                Course updatedCourse = courseService.UpdateCourse(id, course, teacher);
                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(updatedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("{id}/rate")]
        public IActionResult RateCourse(int id, [FromBody] Rating rating, [FromHeader] string credentials)
        {
            try
            {
                Student student = authService.TryGetStudent(credentials);
                Course ratedCourse = courseService.RateCourse(id, rating, student);
                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(ratedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);

            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id, [FromHeader] string credentials)
        {
            try
            {
                Teacher teacher = authService.TryGetTeacher(credentials);
                Course deletedCourse = courseService.DeleteCourse(id, teacher);
                CourseResponseDTO responseDTO = modelMapper.MapToCourseResponseDTO(deletedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
