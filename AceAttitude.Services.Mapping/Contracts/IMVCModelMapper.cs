using AceAttitude.Data.Models;
using AceAttitude.Web.ViewModels;

namespace AceAttitude.Services.Mapping.Contracts
{
    public interface IMVCModelMapper
    {
        // Map to base entities
        public ApplicationUser MapToUser(RegisterViewModel registerViewModel, string passwordHash);

        public ApplicationUser MapToUser(EditUserViewModel editUserViewModel);

        public Course MapToCourse(CourseViewModel courseViewModel);

        public Course MapToCourseEdit(CourseViewModel courseViewModel);

        public Comment MapViewModelToComment(CommentViewModel model);

        public Lecture MapViewModelToLecture(LectureViewModel viewModel);

        // Map to viewmodels

        public UserViewModel MapToUserViewModel(ApplicationUser user);

        public EditUserViewModel MapToEditUserViewModel(ApplicationUser user);

        public ApproveTeacherViewModel MapToApproveTeacher(List<Student> students, List<Teacher> teachers);
    }
}
