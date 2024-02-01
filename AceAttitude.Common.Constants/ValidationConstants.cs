namespace AceAttitude.Common.Constants
{
    public class ValidationConstants
    {
        public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$";
        public const int PasswordMinLength = 8;

        public const int NameMinLength = 2;
        public const int NameMaxLength = 20;
    }
}
