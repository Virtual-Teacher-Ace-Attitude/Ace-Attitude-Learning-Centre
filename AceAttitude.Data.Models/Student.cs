﻿using AceAttitude.Data.Models.Contracts.Role;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceAttitude.Data.Models
{
    public class Student : IsCreatable, IsModifiable, IsDeletable
    {
        public Student()
        {
            this.Id = new Guid().ToString();
        }

        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
