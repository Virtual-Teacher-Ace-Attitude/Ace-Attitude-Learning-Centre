using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.RestAPIControllers
{
    [ApiController]
    [Route("api/courses/{courseId}/comments")]
    public class CommentAPIController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly ICommentService commentService;
        private readonly ICourseService courseService;

        public CommentAPIController(IAuthService authService, ICommentService commentService, ICourseService courseService)
        {
            this.authService = authService;
            this.commentService = commentService;
            this.courseService = courseService;
        }

        [HttpGet("")]
        public IActionResult GetComments(int courseId)
        {
            try
            {
                var course = courseService.GetById(courseId);
                List<Comment> comments = commentService.GetComments(course);
                return Ok(comments);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPost("")]
        public IActionResult PostComment(int courseId, [FromBody] Comment comment, [FromHeader] string credentials)
        {
            try
            {
                var user = authService.TryGetUser(credentials);
                var course = courseService.GetById(courseId);
                Comment createdComment = commentService.CreateComment(comment, course, user);
                return StatusCode(StatusCodes.Status201Created, createdComment);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id, [FromHeader] string credentials)
        {
            try
            {
                var user = authService.TryGetUser(credentials);
                var deletedComment = commentService.DeleteComment(id, user);
                return Ok(deletedComment);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }

        }

        [HttpPost("{id}")]
        public IActionResult EditComment(int id, [FromBody] string content, [FromHeader] string credentials)
        {
            try
            {
                var user = authService.TryGetUser(credentials);
                var updatedComment = commentService.UpdateComment(id, content, user);
                return Ok(updatedComment);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult LikeComment(int id, [FromHeader] string credentials)
        {
            try
            {
                var user = authService.TryGetUser(credentials);
                var comment = commentService.LikeComment(id, user);
                return Ok(comment);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
