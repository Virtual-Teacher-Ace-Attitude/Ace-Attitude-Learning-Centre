using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        public IActionResult Index([FromQuery]string filterParam, [FromQuery]string filterParamValue, [FromQuery] string sortParam)
        {
            List<Course> courses = courseService.GetAll(filterParam, filterParamValue, sortParam);
            return View(courses);
        }
        public IActionResult Details([FromRoute] int id) 
        {
            Course course = courseService.GetById(id);
            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit() 
        {
            return View();
        }

        public IActionResult Delete() 
        {
            return View();
        }

    }
}
