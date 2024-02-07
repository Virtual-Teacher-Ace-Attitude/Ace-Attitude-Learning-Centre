namespace AceAttitude.Common.Constants
{
    public class ValidationConstants
    {
        public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

        public const int PasswordMinLength = 8;

        public const int NameMinLength = 2;
        public const int NameMaxLength = 20;

        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 50;

        public const int DescriptionMaxLength = 1000;

        public const int CommentMinLength = 1;
        public const int CommentMaxLength = 500;
    }
}
