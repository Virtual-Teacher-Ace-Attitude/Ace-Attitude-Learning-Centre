using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data.Models;
using AceAttitude.Services.Mapping.Contracts;
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

        // Map to base entities

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

        public ApplicationUser MapToUser(EditUserViewModel editUserViewModel)
        {
            return new ApplicationUser
            {
                Id = editUserViewModel.Id,
                FirstName = editUserViewModel.FirstName,
                LastName = editUserViewModel.LastName,
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
                Title = viewModel.Title,
                Description = viewModel.Description,
                VideoFilePath = viewModel.VideoFilePath,
                TextFilePath = viewModel.TextFilePath,
            };
        }

        // Map to viewmodels

        public UserViewModel MapToUserViewModel(ApplicationUser user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedOn = user.CreatedOn,
                UserType = user.UserType.ToString(),
            };
        }

        public EditUserViewModel MapToEditUserViewModel(ApplicationUser user)
        {
            return new EditUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }
    }
}
