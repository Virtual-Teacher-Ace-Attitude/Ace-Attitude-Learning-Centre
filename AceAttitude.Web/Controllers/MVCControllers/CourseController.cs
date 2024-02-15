using AceAttitude.Data.Models;
using AceAttitude.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;


        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
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
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPut]
        public IActionResult Edit() 
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete() 
        {
            return View();
        }

    }
}
