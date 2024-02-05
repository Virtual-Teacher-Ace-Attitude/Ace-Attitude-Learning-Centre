namespace AceAttitude.Web.DTO.Response
{
    public class UserResponseDTO
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string UserType { get; set; } = null!;
    }
}
