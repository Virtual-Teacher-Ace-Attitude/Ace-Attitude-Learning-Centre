﻿using AceAttitude.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace AceAttitude.Web.DTO.Request
{
    public class LectureRequestDTO
    {
        private const string TitleMinLengthErrorMessage = "Title must be between 5 and 50 symbols long!";

        private const string DescriptionMaxLengthErrorMessage = "Description cannot be more than 1000 characters long!";

        [Required]
        [StringLength(maximumLength: ValidationConstants.TitleMaxLength,
            MinimumLength = ValidationConstants.TitleMinLength,
            ErrorMessage = TitleMinLengthErrorMessage)]
        public string Title { get; set; } = null!;

        [MaxLength(1000, ErrorMessage = DescriptionMaxLengthErrorMessage)]
        public string? Description { get; set; }

        public string? VideoFilePath { get; set; }

        public string? TextFilePath { get; set; }
    }
}