using AceAttitude.Common.Exceptions;
using AceAttitude.Services;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    [Route("courses/{courseId}/lectures")]
    public class LectureController : Controller
    {


        private readonly ILectureService lectureService;
        private readonly IAuthService authService;
        private readonly IMVCModelMapper modelMapper;
        private readonly IUserService userService;


        public LectureController(ILectureService lectureService, IUserService userService,
            IAuthService authService, IMVCModelMapper modelMapper)
        {
            this.lectureService = lectureService;
            this.authService = authService;
            this.modelMapper = modelMapper;
            this.userService = userService;
        }
        [HttpGet("{lectureId}")]
        public IActionResult Details([FromRoute] int courseId, [FromRoute] int lectureId)
        {
            try
            {
                var user = authService.CurrentUser;
                var lecture = this.lectureService.GetById(lectureId, courseId, user);
                return View(lecture);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpGet]
        [Route("create")]
        public IActionResult CreateLecture([FromRoute] int courseId)
        {
            try
            {
                this.authService.EnsureUserLoggedIn();

                return this.View(new LectureViewModel() { CourseId = courseId });
            }
            catch (UnauthorizedOperationException e)
            {
                return this.Unauthorized(e.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateLecture([FromRoute] int courseId, LectureViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
			var teacher = userService.GetTeacherById(authService.CurrentUser.Id);
			var lecture = modelMapper.MapViewModelToLecture(viewModel);
            lecture.CourseId = courseId;
            var createdLecture = lectureService.CreateLecture(lecture, courseId, teacher);
            return RedirectToAction("Details", "Lecture", new {  courseId, lectureId = createdLecture.Id });

        }


        [HttpGet]
        [Route("delete/{lectureId}")]
        public IActionResult DeleteLecture([FromRoute] int lectureId, [FromRoute] int courseId)
        {
            try
            {
                var user = authService.CurrentUser;
                var lectureToDelete = lectureService.GetById(lectureId, courseId, user);
                return View(lectureToDelete);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        [Route("delete/{lectureId}")]
        public IActionResult DeleteLectureConfirmed([FromRoute] int courseId, [FromRoute] int lectureId)
        {
            try
            {
				//placeholder for authentication
				var teacher = userService.GetTeacherById(authService.CurrentUser.Id);
				_ = lectureService.DeleteLecture(lectureId, courseId, teacher);

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
        [Route("edit/{lectureId}")]
        public IActionResult EditLecture([FromRoute] int courseId, [FromRoute] int lectureId)
        {
            try
            {
                var user = authService.CurrentUser;
                var lecture = lectureService.GetById(lectureId, courseId, user);
                var lectureViewModel = new LectureViewModel()
                {
                    Id = lectureId,
                    CourseId = courseId,
                    Title = lecture.Title,
                    Description = lecture.Description,
                    VideoFilePath = lecture.VideoFilePath,
                    TextFilePath = lecture.TextFilePath,
                };


                return View(lectureViewModel);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        [Route("edit/{lectureId}")]
        public IActionResult EditLecture([FromRoute] int courseId, [FromRoute] int lectureId, LectureViewModel lectureViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(lectureViewModel);
            }

			var teacher = userService.GetTeacherById(authService.CurrentUser.Id);
			var newLecture = modelMapper.MapViewModelToLecture(lectureViewModel);
            lectureService.UpdateLecture(lectureId, courseId, newLecture, teacher);

            return RedirectToAction("Details", "Course", new { id = courseId });
        }


    }
}

