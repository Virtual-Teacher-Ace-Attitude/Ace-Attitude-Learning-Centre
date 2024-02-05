using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/courses/{courseId}/comments")]
    public class CommentAPIController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        private readonly ICourseService courseService;

        public CommentAPIController(IUserService userService, ICommentService commentService, ICourseService courseService)
        {
            this.userService = userService;
            this.commentService = commentService;
            this.courseService = courseService;
        }

        [HttpGet("")]
        public IActionResult GetComments(int courseId)
        {
            var course = courseService.GetById(courseId);
            List<Comment> comments = commentService.GetComments(course);
            return Ok(comments);
        }

        [HttpPost("")]
        public IActionResult PostComment(int courseId, [FromBody] Comment comment, [FromHeader] string userId)
        {
            var user = userService.GetById(userId);
            var course = courseService.GetById(courseId);
            Comment createdComment = commentService.CreateComment(comment, course, user);
            return StatusCode(StatusCodes.Status201Created, createdComment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id, [FromHeader] string userId)
        {
            var user = userService.GetById(userId);
            var deletedComment = commentService.DeleteComment(id, user);
            return Ok(deletedComment);
        }

        [HttpPost("{id}")]
        public IActionResult EditComment(int id, [FromBody] string content, [FromHeader] string userId)
        {
            var user = userService.GetById(userId);
            var updatedComment = commentService.UpdateComment(id, content, user);
            return Ok(updatedComment);
        }

        [HttpPut("{id}")]
        public IActionResult LikeComment(int id, [FromHeader] string userId)
        {
            var user = userService.GetById(userId);
            var comment = commentService.LikeComment(id, user);
            return Ok(comment);
        }
    }
}
