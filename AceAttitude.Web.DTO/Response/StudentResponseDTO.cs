using AceAttitude.Data.Models;

namespace AceAttitude.Web.DTO.Response
{
    public class StudentResponseDTO : UserResponseDTO
    {
        public ICollection<RatingResponseDTO> Ratings { get; set; } = new List<RatingResponseDTO>();

        public ICollection<StudentCoursesResponseDTO> StudentCourses { get; set; } = new List<StudentCoursesResponseDTO>();
    }
}
