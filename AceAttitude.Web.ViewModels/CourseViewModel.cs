using AceAttitude.Common.Constants;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using AceAttitude.Data.Models.Misc;

namespace AceAttitude.Web.ViewModels
{
	public class CourseViewModel
	{
		private const string TitleMinLengthErrorMessage = "Title must be between 5 and 50 symbols long!";
		private const string DescriptionMaxLengthErrorMessage = "Description cannot be more than 1000 characters long!";

		public int Id { get; set; }

		[Required]
		[StringLength(maximumLength: ValidationConstants.TitleMaxLength,
		MinimumLength = ValidationConstants.TitleMinLength,
		 ErrorMessage = TitleMinLengthErrorMessage)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(1000, ErrorMessage = DescriptionMaxLengthErrorMessage)]
		public string Description { get; set; } = null!;

		public string Level { get; set; } = null!;

		public string AgeGroup { get; set; } = null!;

		public SelectList? Levels { get; set; }
		public SelectList? AgeGroups { get; set; }

	}
}
