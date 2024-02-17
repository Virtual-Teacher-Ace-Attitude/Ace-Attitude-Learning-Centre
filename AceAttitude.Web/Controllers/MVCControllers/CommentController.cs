using AceAttitude.Common.Exceptions;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly ICourseService courseService;
        private readonly IAuthService authService;
        private readonly IMVCModelMapper modelMapper;

        public CommentController(ICommentService commentService, ICourseService courseService, 
            IAuthService authService, IMVCModelMapper modelMapper)
        {
            this.commentService = commentService;
            this.courseService = courseService;
            this.authService = authService;
            this.modelMapper = modelMapper;
        }

        [HttpGet]
        [Route("course/{courseId}/comment")]
        public IActionResult AddComment([FromRoute] int courseId)
        {
            try
            {
                this.authService.EnsureUserLoggedIn();

                return this.View(new CommentViewModel());
            }
            catch (UnauthorizedOperationException e)
            {
                return this.Unauthorized(e.Message);
            }
        }

        [HttpPost]
        [Route("course/{courseId}/comment")]
        public IActionResult AddComment([FromRoute] int courseId, CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = authService.CurrentUser;
            var course = courseService.GetById(courseId);
            var comment = modelMapper.MapViewModelToComment(model);
            comment.CourseId = courseId;
            comment.ApplicationUserId = user.Id;
            var createdComment = commentService.CreateComment(comment, course, user);
            return RedirectToAction("Details", "Course", new { courseId });

        }


        [HttpGet]
        [Route("course/{courseId}/{commentId}/delete")]
        public IActionResult DeleteComment([FromRoute] int commentId, [FromRoute] int courseId)
        {
            try
            {
                var commentToDelete = commentService.GetComment(commentId, courseId);
                return View(commentToDelete);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        [Route("course/{courseId}/{commentId}/delete")]
        public IActionResult DeleteCommentConfirmed([FromRoute] int courseId, [FromRoute] int commentId)
        {
            try
            {
                //placeholder for authentication
                var user = authService.CurrentUser;
                _ = commentService.DeleteComment(commentId, courseId, user);

                return RedirectToAction("Details", "Course", new { id = courseId });
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpGet]
        [Route("course/{courseId}/{commentId}/edit")]
        public IActionResult EditComment([FromRoute] int courseId, [FromRoute] int commentId)
        {
            try
            {
                var user = authService.CurrentUser;
                var course = courseService.GetById(courseId);
                var comment = commentService.GetComment(commentId, courseId);
                var commentViewModel = new CommentViewModel()
                {
                    Id = comment.Id,
                    CourseId = courseId,
                    Content = comment.Content,
                };


                return View(commentViewModel);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        [Route("course/{courseId}/{commentId}/edit")]
        public IActionResult EditComment([FromRoute] int courseId, [FromRoute] int commentId, CommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(commentViewModel);
            }

            var user = authService.CurrentUser;
            commentService.UpdateComment(commentId, courseId, commentViewModel.Content, user);

            return RedirectToAction("Details", "Course", new { id = courseId });
        }

        [HttpPost]
        [Route("course/{courseId}/{commentId}/like")]
        public IActionResult LikeComment([FromRoute] int courseId, [FromRoute] int commentId)
        {
            var user = authService.CurrentUser;
            authService.EnsureUserLoggedIn();
            commentService.LikeComment( commentId, courseId, user);
            return RedirectToAction("Details", "Course", new { id = courseId });
        }
    }
}
