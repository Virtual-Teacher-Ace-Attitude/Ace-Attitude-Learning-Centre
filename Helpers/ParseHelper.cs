using AceAttitude.Common.Exceptions;
using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Common.Helpers
{
    public class ParseHelper : IParseHelper
    {
        private const string InvalidCredentialsErrorMessage = "Credentials are not in the valid format - Username|Password.";

        private const string InvalidAgeGroupErrorMessage = "{0} is not a valid age group.";

        private const string InvalidLevelErrorMessage = "{0} is not a valid level.";

        private const string InvalidRatingErrorMessage = "Rating must be a decimal number.";

        public string EnsureValidCredentials(string credentials)
        {
            if (!credentials.Contains('|')) 
            {
                throw new InvalidUserInputException(InvalidCredentialsErrorMessage);
            }

            return credentials;
        }

        public AgeGroup ParseAge(string paramValue)
        {
            if (Enum.TryParse(paramValue, out AgeGroup age))
            {
                return age;
            }
            else
            {
                throw new InvalidUserInputException(string.Format(InvalidAgeGroupErrorMessage, paramValue));
            }

        }

        public Level ParseLevel(string paramValue)
        {
            if (Enum.TryParse(paramValue, out Level level))
            {
                return level;
            }
            else
            {
                throw new InvalidUserInputException(string.Format(InvalidLevelErrorMessage, paramValue));
            }

        }

        public decimal ParseRating(string paramValue)
        {
            if (decimal.TryParse(paramValue, out decimal rating))
            {
                return rating;
            }
            else
            {
                throw new InvalidUserInputException(InvalidRatingErrorMessage);
            }

        }
    }
}
