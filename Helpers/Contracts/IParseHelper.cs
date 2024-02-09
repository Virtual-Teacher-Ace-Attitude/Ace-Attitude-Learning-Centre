using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Common.Helpers.Contracts
{
    public interface IParseHelper
    {
        public AgeGroup ParseAge(string paramValue);

        public Level ParseLevel(string paramValue);

        public decimal ParseRating(string paramValue);

        public string ParseCredentials(string credentials);
    }
}
