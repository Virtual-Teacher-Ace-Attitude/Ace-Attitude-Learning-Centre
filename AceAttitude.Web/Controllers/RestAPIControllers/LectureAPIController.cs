using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/lectures")]
    public class LectureAPIController : ControllerBase
    {
        private readonly ILectureService lectureService;
        private readonly IUserService userService;

        public LectureAPIController(ILectureService lectureService, IUserService userService)
        {
            this.lectureService = lectureService;
            this.userService = userService;
        }
        //These are placeholder methods to be properly implemented with authentication, authorization and exception handling!
        //UserId should be replaced with proper credentials.

        [HttpGet("{id}")]
        public IActionResult GetLectureById(int id)
        {
            return Ok(lectureService.GetById(id));
        }

        [HttpPost("")]
        public IActionResult CreateCourse(Lecture lecture, [FromHeader] int userId)
        {
            var user = userService.GetById(userId);
            var createdLecture = lectureService.CreateLecture(lecture, user);
            return StatusCode(StatusCodes.Status201Created, createdLecture);
        }

        [HttpPut("{id}/edit")]
        public IActionResult UpdateCourse(int id, [FromBody] Lecture lecture, [FromHeader] int userId)
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
