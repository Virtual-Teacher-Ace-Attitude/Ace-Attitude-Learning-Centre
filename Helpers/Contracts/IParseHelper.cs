using AceAttitude.Common.Exceptions;
using AceAttitude.Data.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Common.Helpers.Contracts
{
    public interface IParseHelper
    {
        public AgeGroup ParseAge(string paramValue);


        public Level ParseLevel(string paramValue);


        public decimal ParseRating(string paramValue);

    }
}
