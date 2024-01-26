using AceAttitude.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Data.Models
{

    public class Rating
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public ICourse Course { get; set; }

        public int? UserId { get; set; }
        public IUser User { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
    }
}
