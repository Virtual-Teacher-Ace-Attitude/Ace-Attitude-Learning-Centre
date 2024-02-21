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
        private readonly IWebHostEnvironment webHostEnvironment;


        public LectureController(ILectureService lectureService, IUserService userService,
            IAuthService authService, IMVCModelMapper modelMapper, IWebHostEnvironment webHostEnvironment)
        {
            this.lectureService = lectureService;
            this.authService = authService;
            this.modelMapper = modelMapper;
            this.userService = userService;
            this.webHostEnvironment = webHostEnvironment;
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
            return RedirectToAction("Details", "Lecture", new { courseId, lectureId = createdLecture.Id });

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

        [HttpGet("{lectureId}/assignment")]
        public IActionResult GetAssignmentFile([FromRoute] int lectureId, [FromRoute] int courseId)
        {
            var user = authService.CurrentUser;
            var lecture = lectureService.GetById(lectureId, courseId, user);
            string fileName = $"{lecture.Title}: assignment";
            string filePath = Path.Combine(webHostEnvironment.WebRootPath, "assignments", lecture.TextFilePath);
            if (System.IO.File.Exists(filePath))
            {

                // Read the file content into a byte array
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                // Set Content-Type header to specify the file type
                Response.Headers["Content-Type"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                // Set Content-Disposition header to force download with correct filename
                Response.Headers["Content-Disposition"] = $"attachment; filename=\"{fileName}.docx\"";

                // Return the file content as a downloadable file
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            }
            else
            {
                // If the file doesn't exist, return a not found response
                return NotFound();
            }
        }
        [HttpPost("{lectureId}/assignment")]
        public IActionResult AddAssignment(IFormFile file, [FromRoute] int lectureId, [FromRoute] int courseId)
        {
            if (file != null)
            {
                // Save the uploaded file to a location
                // For example, save it to the wwwroot folder
                var user = authService.CurrentUser;
                var teacher = userService.GetTeacherById(authService.CurrentUser.Id);
                var lectureToUpdate = lectureService.GetById(lectureId, courseId, user);
                lectureToUpdate.TextFilePath = file.FileName;
                lectureService.UpdateLecture(lectureId, courseId, lectureToUpdate, teacher);
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, "assignments", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return RedirectToAction("Details", "Lecture", new { courseId, lectureId }); // Redirect to a different action after successful upload
            }
            else
            {
                // Handle the case when no file is uploaded
                return View("Error"); // Redirect to an error page or display an error message
            }
        }

        [HttpPost("{lectureId}/submit")]
        public IActionResult SubmitAssignment(IFormFile file, [FromRoute]int lectureId, [FromRoute] int courseId)
        {
            if (file != null && file.Length > 0)
            {
                // Save the uploaded file to a location
                // For example, save it to the wwwroot folder
                var user = authService.CurrentUser;
                var lecture = lectureService.GetById(lectureId, courseId, user);
                string lectureFolderPath = Path.Combine(webHostEnvironment.WebRootPath, "submissions", $"{lecture.Title}");
                if (!Directory.Exists(lectureFolderPath))
                {
                    Directory.CreateDirectory(lectureFolderPath);
                }
                var filePath = Path.Combine(webHostEnvironment.WebRootPath, "submissions", $"{lecture.Title}", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return RedirectToAction("Details", "Lecture", new { courseId, lectureId }); // Redirect to a different action after successful upload
            }
            else
            {
                // Handle the case when no file is uploaded
                return View("Error"); // Redirect to an error page or display an error message
            }
        }

    }
}

