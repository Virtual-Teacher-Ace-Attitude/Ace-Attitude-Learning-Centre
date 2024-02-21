using AceAttitude.Data.Models;

namespace AceAttitude.Web.ViewModels
{
    public class StudentCourseViewModel
    {
        public List<Course> Courses { get; set; } = new List<Course>();

        public string AverageGrade { get; set; } = null!;
    }
}
