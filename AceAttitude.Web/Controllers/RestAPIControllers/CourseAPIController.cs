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
        private readonly IModelMapper modelMapper;

        public CourseAPIController(ICourseService courseService, IAuthService authService, IModelMapper modelMapper)
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
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidUserInputException ex)
            {
                return BadRequest(ex.Message);
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
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
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

                var teacher = authService.TryGetTeacher(credentials);
                var course = modelMapper.MapToCourse(courseRequestDTO);
                var createdCourse = courseService.CreateCourse(course, teacher);
                var responseDTO = modelMapper.MapToCourseResponseDTO(createdCourse);
                return StatusCode(StatusCodes.Status201Created, responseDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (InvalidUserInputException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseRequestDTO courseRequestDTO, [FromHeader] string credentials)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    throw new InvalidUserInputException(InvalidCourseCreationErrorMessage);
                }

                var teacher = authService.TryGetTeacher(credentials);
                var course = modelMapper.MapToCourse(courseRequestDTO);
                var updatedCourse = courseService.UpdateCourse(id, course, teacher);
                var responseDTO = modelMapper.MapToCourseResponseDTO(updatedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (InvalidUserInputException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult RateCourse(int id, [FromBody] Rating rating, [FromHeader] string credentials)
        {
            try
            {
                var student = authService.TryGetStudent(credentials);
                var ratedCourse = courseService.RateCourse(id, rating, student);
                var responseDTO = modelMapper.MapToCourseResponseDTO(ratedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);

            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id, [FromHeader] string credentials)
        {
            try
            {
                var teacher = authService.TryGetTeacher(credentials);
                var deletedCourse = courseService.DeleteCourse(id, teacher);
                var responseDTO = modelMapper.MapToCourseResponseDTO(deletedCourse);
                return Ok(responseDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }

        }
    }
}
