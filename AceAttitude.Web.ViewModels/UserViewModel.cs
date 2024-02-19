namespace AceAttitude.Web.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string UserType { get; set; } = null!;
    }
}
