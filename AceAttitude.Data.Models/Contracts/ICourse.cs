using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Data.Models.Contracts
{
    public interface ICourse
    {
        string Title { get; set; }

        AgeGroup AgeGroup { get; set; }

        Level Level { get; set; }

        string Description { get; set; }

        DateTime StartingDate { get; set; }

        List<ILecture> Lectures { get; set; }
    }
}
