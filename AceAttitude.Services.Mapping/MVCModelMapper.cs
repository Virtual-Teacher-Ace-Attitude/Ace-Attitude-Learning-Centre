using AceAttitude.Common.Helpers;
using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models;
using AceAttitude.Services.Mapping.Contracts;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.ViewModels;

namespace AceAttitude.Services.Mapping
{
    public class MVCModelMapper : IMVCModelMapper
    {
        private readonly IParseHelper parseHelper;
        public MVCModelMapper(IParseHelper parseHelper)
        {
            this.parseHelper = parseHelper;
        }
        public ApplicationUser MapToUser(RegisterViewModel registerViewModel, string passwordHash)
        {
            return new ApplicationUser
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                PasswordHash = passwordHash,
                CreatedOn = DateTime.Now,
            };
        }

        public Course MapToCourse(CourseViewModel courseViewModel)
        {
            return new Course
            {
                Title = courseViewModel.Title,
                Description = courseViewModel.Description,
            };
        }

        public Comment MapViewModelToComment(CommentViewModel model)
        {
            return new Comment()
            {
                Content = model.Content
            };
        }

        public Lecture MapViewModelToLecture(LectureViewModel viewModel)
        {
            return new Lecture()
            {
                Title= viewModel.Title,
                Description= viewModel.Description,
                VideoFilePath= viewModel.VideoFilePath,
                TextFilePath= viewModel.TextFilePath,
            };
        }
    }
}
