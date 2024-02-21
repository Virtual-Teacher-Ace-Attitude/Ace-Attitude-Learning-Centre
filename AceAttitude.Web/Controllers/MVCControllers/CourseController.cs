using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Services;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Response;
using AceAttitude.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IAuthService authService;
        private readonly IMVCModelMapper modelMapper;
        private readonly IUserService userService;


        public CourseController(ICourseService courseService, IAuthService authService,
            IMVCModelMapper modelMapper, IUserService userService)
        {
            this.courseService = courseService;
            this.authService = authService;
            this.modelMapper = modelMapper;
            this.userService = userService;
        }
        [HttpGet("")]
        public IActionResult Index([FromQuery] string filterParam = "none", [FromQuery] string filterParamValue = "none", [FromQuery] string sortParam = "none")
        {
            List<Course> courses = courseService.GetAll(filterParam, filterParamValue, sortParam);
            return View(courses);
        }

        [HttpGet("{id}")]
        public IActionResult Details([FromRoute] int id)
        {
            Course course = courseService.GetById(id);

            return View(course);
        }



        [HttpGet("create")]
        public IActionResult Create()
        {
            try
            {

                this.authService.EnsureUserLoggedIn();

                var courseViewModel = new CourseViewModel();
                InitializeDropDownLists(courseViewModel);

                return this.View(courseViewModel);
            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }

        }

        [HttpPost("create")]
        public IActionResult Create(CourseViewModel model)
        {
            try
            {
                this.authService.EnsureUserLoggedIn();

                if (!ModelState.IsValid)
                {
                    InitializeDropDownLists(model);
                    return View(model);
                }
                var user = authService.CurrentUser;
                var teacher = userService.GetTeacherById(user.Id);
                var course = modelMapper.MapToCourse(model);
                course.TeacherId = teacher.Id;
                var createdCourse = courseService.CreateCourse(course, teacher);
                return RedirectToAction("Details", "Course", new { id = createdCourse.Id });

            }
            catch (UnauthorizedOperationException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpGet("{id}/delete")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var course = courseService.GetById(id);

                return View(course);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpPost("{id}/delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            try
            {
                //placeholder for authentication
                var user = authService.CurrentUser;
                var teacher = userService.GetTeacherById(user.Id);
                _ = courseService.DeleteCourse(id, teacher);

                return RedirectToAction("Index", "Post");
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult ReleaseCourse(int courseId)
        {
            try
            {
                ApplicationUser requestUser = this.authService.CurrentUser;

                Teacher teacher = this.userService.GetTeacherById(requestUser.Id);

                Course releasedCourse = courseService.ReleaseCourse(courseId, teacher);

                return RedirectToAction("Details", "Course", new { id = releasedCourse.Id });
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
            catch (InvalidUserInputException ex)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpGet("{id}/admit")]
        public IActionResult Admit([FromRoute] int id)
        {
            try
            {
                this.authService.EnsureUserLoggedIn();
                ApplicationUser requestUser = this.authService.CurrentUser;

                Course course = this.courseService.GetById(id);

                ICollection<StudentCourses> studentCourses = this.courseService.GetUnapprovedStudentCourses(id);

                return View(studentCourses);
            }
            catch (UnauthorizedOperationException e)
            {
                return this.ForbiddenOperation(e.Message, StatusCodes.Status401Unauthorized);
            }
            catch (EntityNotFoundException e)
            {
                return this.ForbiddenOperation(e.Message, StatusCodes.Status404NotFound);
            }
        }

        [HttpPost("{id}/admitStudent")]
        public IActionResult AdmitStudentMVC(int studentcourseid)
        {
            try
            {
                this.authService.EnsureUserLoggedIn();
                ApplicationUser requestUser = this.authService.CurrentUser;
                Teacher requestTeacher = this.userService.GetTeacherById(requestUser.Id);

                StudentCourses studentCourse = this.courseService.GetStudentCourse(studentcourseid);

                this.courseService.AdmitStudent(studentCourse.CourseId, studentCourse.StudentId, requestTeacher);

                return RedirectToAction("Admit", "Course", new { id = studentCourse.CourseId });
            }
            catch (UnauthorizedOperationException e)
            {
                return this.ForbiddenOperation(e.Message, StatusCodes.Status401Unauthorized);
            }
            catch (EntityNotFoundException e)
            {
                return this.ForbiddenOperation(e.Message, StatusCodes.Status404NotFound);
            }
        }

        [HttpGet]
        [Route("{id}/edit")]
        public IActionResult Edit([FromRoute] int id)
        {
            try
            {
                var course = courseService.GetById(id);
                var courseViewModel = new CourseViewModel()
                {
                    Id = id,
                    Title = course.Title,
                    Description = course.Description,
                    Level = course.Level.ToString(),
                    AgeGroup = course.AgeGroup.ToString(),

                };

                return View(courseViewModel);
            }
            catch (EntityNotFoundException ex)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                ViewData["ErrorMessage"] = ex.Message;

                return View("Error");
            }
        }

        [HttpPost]
        [Route("{id}/edit")]
        public IActionResult Edit([FromRoute] int id, CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(courseViewModel);
            }
            var user = authService.CurrentUser;
            var teacher = userService.GetTeacherById(user.Id);
            var course = modelMapper.MapToCourse(courseViewModel);
            var updatedCourse = courseService.UpdateCourse(id, course, teacher);

            return RedirectToAction("Details", "Course", new { id = updatedCourse.Id });
        }

        [HttpGet("{id}/rate")]
        public IActionResult RateCourse([FromRoute] int courseId)
        {
            var user = authService.CurrentUser;
            var student = userService.GetStudentById(user.Id);
            RatingViewModel viewModel = new RatingViewModel();
            viewModel.CourseId = courseId;
            viewModel.StudentId = student.Id;
            return View(viewModel);
        }

        [HttpPost("{id}/rate")]
        public IActionResult RateCourse(RatingViewModel viewModel)
        {
            var user = authService.CurrentUser;
            var student = userService.GetStudentById(user.Id);
            courseService.RateCourse(viewModel.CourseId, viewModel.Value, student);
            return RedirectToAction("Details", "Course", new { id = viewModel.CourseId });
            
        }


        private void InitializeDropDownLists(CourseViewModel viewModel)
		{
			IEnumerable<SelectListItem> levelSelectListItems = Enum.GetValues(typeof(Level))
				.Cast<Level>()
				.Select(l => new SelectListItem
				{
					Value = l.ToString(),
					Text = l.ToString()
				});

			// Create SelectList from the SelectListItems
			viewModel.Levels = new SelectList(levelSelectListItems, "Value", "Text");

			IEnumerable<SelectListItem> ageSelectListItems = Enum.GetValues(typeof(AgeGroup))
		        .Cast<AgeGroup>()
		        .Select(l => new SelectListItem
		        {
		        	Value = l.ToString(),
		        	Text = l.ToString()
		        });

			// Create SelectList from the SelectListItems
			viewModel.AgeGroups = new SelectList(ageSelectListItems, "Value", "Text");

		}

        private IActionResult ForbiddenOperation(string errorMessage, int statusCode)
        {
            Response.StatusCode = statusCode;
            ViewData["ErrorMessage"] = errorMessage;

            return View(viewName: "Error");
        }
    }
}
