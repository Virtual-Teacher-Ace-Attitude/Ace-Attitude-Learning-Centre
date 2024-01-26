using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Data.Models.Contracts
{
    public interface ILecture
    {
        string Title { get; set; }

        string Description { get; set; }

        
    }
}
