using AceAttitude.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    public class HomeController : Controller
    {
        private readonly ICourseRepository courseRepository;

        public HomeController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            var courses = this.courseRepository.GetHomeCourses();

            return View(courses);
        }

        public IActionResult About() 
        {
            return View();
        }
    }
}
