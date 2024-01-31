﻿using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Data.Models
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }

        public Course Course { get; set; } = null!;

        [Required]
        public int CourseId { get; set; }

        public Student Student { get; set; } = null!;

        [Required]
        public string StudentId { get; set; } = null!;
    }
}
