using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Data.Models
{
    internal static class ModelErrorMessages
    {
        internal const string NameMinLengthErrorMessage = "Name must be at least 2 characters long";
        internal const string NameMaxLengthErrorMessage = "Name cannot be more than 20 characters long";
        internal const string TitleMinLengthErrorMessage = "Name must be at least 5 characters long";
        internal const string TitleMaxLengthErrorMessage = "Name cannot be more than 50 characters long";
        internal const string DescriptionMaxLengthErrorMessage = "Description cannot be more than 1000 characters long.";
    }
}
