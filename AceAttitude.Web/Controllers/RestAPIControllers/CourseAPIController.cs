using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseAPIController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly IUserService userService;

        public CourseAPIController(ICourseService courseService, IUserService userService)
        {
            this.courseService = courseService;
            this.userService = userService;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.
        [HttpGet("")]
        public IActionResult GetAll([FromBody] string filterParam, 
            [FromBody] string filterParamValue, [FromBody] string sortParam) 
        {
            return Ok(courseService.GetAll(filterParam, filterParamValue, sortParam));
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            return Ok(courseService.GetById(id));
        }

        [HttpPost("")]
        public IActionResult CreateCourse(Course course, [FromHeader] int userId)
        {
            var user = userService.GetById(userId);
            var createdCourse = courseService.CreateCourse(course, user);
            return StatusCode(StatusCodes.Status201Created, createdCourse);
        }

        [HttpPost("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course, [FromHeader] int userId)
        {
            var user = userService.GetById(userId);
            var updatedCourse = courseService.UpdateCourse(id, course, user);
            return Ok(updatedCourse);

        }

        [HttpPut("{id}")]
        public IActionResult RateCourse(int id, [FromBody] Rating rating, [FromHeader] int userId) 
        {
            var user = userService.GetById(userId);
            var ratedCourse = courseService.RateCourse(id, rating, user);
            return Ok(ratedCourse);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id, [FromHeader] int userId)
        {
            var user = userService.GetById(userId);
            var deletedCourse = courseService.DeleteCourse(id, user);
            return Ok(deletedCourse);
        }


    }
}
