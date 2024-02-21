using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Web.ViewModels
{
    public class RatingViewModel
    {
        public int CourseId { get; set; }

        public string StudentId { get; set; } = null!;
        public decimal Value { get; set; }
    }
}
