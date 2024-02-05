using AceAttitude.Data.Models;

namespace AceAttitude.Web.DTO.Response
{
    public class StudentResponseDTO : UserResponseDTO
    {
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
    }
}
