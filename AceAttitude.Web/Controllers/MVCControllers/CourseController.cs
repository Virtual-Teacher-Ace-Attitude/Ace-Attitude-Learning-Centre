using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models;
using AceAttitude.Data.Models.Misc;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping.Contracts;
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


        public CourseController(ICourseService courseService, IAuthService authService, IMVCModelMapper modelMapper)
        {
            this.courseService = courseService;
            this.authService = authService; 
            this.modelMapper = modelMapper;
        }
        [HttpGet("")]
        public IActionResult Index([FromQuery] string filterParam, [FromQuery] string filterParamValue, [FromQuery] string sortParam)
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
                var teacher = authService.TryGetTeacher(authService.CurrentUser.Id);
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

        [HttpDelete("{id}/delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            try
            {
                //placeholder for authentication
                var teacher = authService.TryGetTeacher(authService.CurrentUser.Id);
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

            var teacher = authService.TryGetTeacher(authService.CurrentUser.Id);
            var course = modelMapper.MapToCourse(courseViewModel);
            var updatedCourse = courseService.UpdateCourse(id, course, teacher);

            return RedirectToAction("Details", "Course", new { id = updatedCourse.Id });
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
	}
}
