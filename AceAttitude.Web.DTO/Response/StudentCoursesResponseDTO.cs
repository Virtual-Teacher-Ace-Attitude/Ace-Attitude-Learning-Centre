namespace AceAttitude.Web.DTO.Response
{
    public class StudentCoursesResponseDTO
    {
        public string Course { get; set; } = null!;

        public bool IsCompleted { get; set; }

        public DateTime EnrollDate { get; set; }
    }
}
