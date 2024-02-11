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
    [Route("api/courses/{courseId}/comments")]
    public class CommentAPIController : ControllerBase
    {
        private readonly IAuthService authService;

        private readonly IAPIModelMapper modelMapper;

        private readonly ICommentService commentService;
        private readonly ICourseService courseService;

        public CommentAPIController(IAuthService authService, ICommentService commentService, ICourseService courseService, IAPIModelMapper modelMapper)
        {
            this.authService = authService;
            this.commentService = commentService;
            this.courseService = courseService;
            this.modelMapper = modelMapper;
        }

        [HttpGet("")]
        public IActionResult GetComments(int courseId)
        {
            try
            {
                Course course = courseService.GetById(courseId);

                ICollection<CommentResponseDTO> commentsAsDto = this.commentService.GetComments(course)
                    .Select(this.modelMapper.MapToCommentResponseDTO).ToList();

                return Ok(commentsAsDto);
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
        public IActionResult PostComment(int courseId, [FromBody] CommentRequestDTO commentRequestDTO, [FromHeader] string credentials)
        {
            try
            {
                ApplicationUser user = authService.TryGetUser(credentials);
                Course course = courseService.GetById(courseId);

                Comment commentToCreate = this.modelMapper.MapToComment(commentRequestDTO);
                commentToCreate.ApplicationUserId = user.Id;

                Comment createdComment = commentService.CreateComment(commentToCreate, course, user);

                CommentResponseDTO commentResponseDto = this.modelMapper.MapToCommentResponseDTO(createdComment);

                return StatusCode(StatusCodes.Status201Created, commentResponseDto);
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
        public IActionResult DeleteComment(int id, [FromHeader] string credentials)
        {
            try
            {
                ApplicationUser user = authService.TryGetUser(credentials);

                Comment deletedComment = commentService.DeleteComment(id, user);

                CommentResponseDTO commentResponseDto = this.modelMapper.MapToCommentResponseDTO(deletedComment);

                return Ok(commentResponseDto);
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

        [HttpPut("{commentId}")]
        public IActionResult EditComment([FromRoute]int commentId, [FromRoute] int courseId, 
            [FromBody] CommentRequestDTO commentRequestDTO, [FromHeader] string credentials)
        {
            try
            {
                ApplicationUser user = authService.TryGetUser(credentials);

                Comment updatedComment = commentService.UpdateComment(commentId, commentRequestDTO.Content, user);

                CommentResponseDTO commentResponseDto = this.modelMapper.MapToCommentResponseDTO(updatedComment);

                return Ok(commentResponseDto);
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

        [HttpPut("{id}/like")]
        public IActionResult LikeComment(int id, [FromHeader] string credentials)
        {
            try
            {
                ApplicationUser user = authService.TryGetUser(credentials);

                Comment comment = commentService.LikeComment(id, user);

                CommentResponseDTO commentResponseDto = this.modelMapper.MapToCommentResponseDTO(comment);

                return Ok(commentResponseDto);
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
