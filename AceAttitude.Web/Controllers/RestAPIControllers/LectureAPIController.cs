using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/courses/{courseId}/lectures")]
    public class LectureAPIController : ControllerBase
    {
        private readonly ILectureService lectureService;
        private readonly IUserService userService;
        private readonly ICourseService courseService;

        public LectureAPIController(ILectureService lectureService, IUserService userService, ICourseService courseService)
        {
            this.lectureService = lectureService;
            this.userService = userService;
            this.courseService = courseService; 
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.

        [HttpGet("{id}")]
        public IActionResult GetLectureById(int id)
        {
            return Ok(lectureService.GetById(id));
        }

        [HttpPost("")]
        public IActionResult CreateLecture(Lecture lecture, int courseId, [FromHeader] int userId)
        {
            var user = userService.GetById(userId);
            var course = courseService.GetById(courseId);
            var createdLecture = lectureService.CreateLecture(lecture, course, user);
            return StatusCode(StatusCodes.Status201Created, createdLecture);
        }

        [HttpPost("{id}")]
        public IActionResult UpdateLecture(int id, [FromBody] Lecture lecture, [FromHeader] int userId)
        {
            var user = userService.GetById(userId);
            var updatedLecture = lectureService.UpdateLecture(id, lecture, user);
            return Ok(updatedLecture);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id, [FromHeader] int userId)
        {
            var user = userService.GetById(userId);
            var deletedLecture = lectureService.DeleteLecture(id, user);
            return Ok(deletedLecture);
        }
    }
}
