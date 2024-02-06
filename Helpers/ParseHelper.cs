using AceAttitude.Common.Exceptions;
using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models.Misc;
namespace AceAttitude.Common.Helpers
{
    public class ParseHelper : IParseHelper
    {
        public AgeGroup ParseAge(string paramValue)
        {
            if (Enum.TryParse(paramValue, out AgeGroup age))
            {
                return age;
            }
            else
            {
                throw new ArgumentException($"{paramValue} is not a valid age group.");
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
                throw new InvalidUserInputException($"{paramValue} is not a valid level.");
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
                throw new InvalidUserInputException("Rating must be a decimal number.");
            }

        }
    }
}
