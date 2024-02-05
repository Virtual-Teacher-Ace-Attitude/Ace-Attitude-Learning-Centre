namespace AceAttitude.Web.DTO.Response
{
    public class LectureResponseDTO
    {
        public string Course { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string? VideoFilePath { get; set; }

        public string? TextFilePath { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
