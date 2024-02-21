using AceAttitude.Data.Models;

namespace AceAttitude.Web.ViewModels
{
    public class ApproveTeacherViewModel
    {
        public List<Student> students = new List<Student>();
        public List<Teacher> teachers = new List<Teacher>();

        public string SelectedId { get; set; } = null!;
    }
}
