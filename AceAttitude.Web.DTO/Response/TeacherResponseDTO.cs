﻿using AceAttitude.Data.Models;

namespace AceAttitude.Web.DTO.Response
{
    public class TeacherResponseDTO : UserResponseDTO
    {
        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public ICollection<Course> CreatedCourses { get; set; } = new List<Course>();
    }
}