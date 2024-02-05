using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Services;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseAPIController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly IUserService userService;
        private readonly IAuthService authService;

        public CourseAPIController(ICourseService courseService, IUserService userService, IAuthService authService)
        {
            this.courseService = courseService;
            this.userService = userService;
            this.authService = authService;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.
        [HttpGet("")]
        public IActionResult GetAll([FromQuery] string filterParam,
            [FromQuery] string filterParamValue, [FromQuery] string sortParam)
        {
            try
            {
                return Ok(courseService.GetAll(filterParam, filterParamValue, sortParam));
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
                return Ok(courseService.GetById(id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost("")]
        public IActionResult CreateCourse(Course course, [FromHeader] string credentials)
        {
            try
            {
                var teacher = authService.TryGetTeacher(credentials);
                var createdCourse = courseService.CreateCourse(course, teacher);
                return StatusCode(StatusCodes.Status201Created, createdCourse);
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

        [HttpPost("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course, [FromHeader] string credentials)
        {
            try
            {
                var teacher = authService.TryGetTeacher(credentials);
                var updatedCourse = courseService.UpdateCourse(id, course, teacher);
                return Ok(updatedCourse);
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

        [HttpPut("{id}")]
        public IActionResult RateCourse(int id, [FromBody] Rating rating, [FromHeader] string credentials)
        {
            try
            {
                var student = authService.TryGetStudent(credentials);
                var ratedCourse = courseService.RateCourse(id, rating, student);
                return Ok(ratedCourse);
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
                return Ok(deletedCourse);
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }

        }


    }
}
