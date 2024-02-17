using AceAttitude.Common.Exceptions;
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


        public LectureController(ILectureService lectureService, ICourseService courseService,
            IAuthService authService, IMVCModelMapper modelMapper)
        {
            this.lectureService = lectureService;
            this.authService = authService;
            this.modelMapper = modelMapper;
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
        public IActionResult CreateLecture()
        {
            try
            {
                this.authService.EnsureUserLoggedIn();

                return this.View(new LectureViewModel());
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
            var teacher = authService.TryGetTeacher(authService.CurrentUser.Id);
            var lecture = modelMapper.MapViewModelToLecture(viewModel);
            lecture.CourseId = courseId;
            var createdLecture = lectureService.CreateLecture(lecture, courseId, teacher);
            return RedirectToAction("Details", "Lecture", new { createdLecture.Id });

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

        [HttpDelete]
        [Route("delete/{lectureId}")]
        public IActionResult DeleteLectureConfirmed([FromRoute] int courseId, [FromRoute] int commentId)
        {
            try
            {
                //placeholder for authentication
                var teacher = authService.TryGetTeacher(authService.CurrentUser.Id);
                _ = lectureService.DeleteLecture(commentId, courseId, teacher);

                return RedirectToAction("Details", "Course", new { courseId });
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

        [HttpPut]
        [Route("edit/{lectureId}")]
        public IActionResult EditLecture([FromRoute] int courseId, [FromRoute] int lectureId, LectureViewModel lectureViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(lectureViewModel);
            }

            var teacher = authService.TryGetTeacher(authService.CurrentUser.Id);
            var newLecture = modelMapper.MapViewModelToLecture(lectureViewModel);
            lectureService.UpdateLecture(lectureId, courseId, newLecture, teacher);

            return RedirectToAction("Details", "Course", new { courseId });
        }


    }
}

