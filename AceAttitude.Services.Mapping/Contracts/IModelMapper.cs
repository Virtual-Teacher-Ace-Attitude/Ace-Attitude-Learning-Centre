using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;

namespace AceAttitude.Services.Mapping.Contracts
{
    public interface IModelMapper
    {
        // Map to base entities
        public Student MapToStudentLite(ApplicationUser user);

        public Teacher MapToTeacherLite(ApplicationUser user);

        public Student MapToStudent(ApplicationUser user);

        public Teacher MapToTeacher(ApplicationUser user);

        public Lecture MapToLecture(LectureRequestDTO lectureRequestDTO, Course course);

        public Course MapToCourse(CourseRequestDTO courseRequestDTO);

        public ApplicationUser MapToUser(UserRegisterRequestDTO userDTO, string passwordHash);

        public ApplicationUser MapToUser(UserUpdateRequestDTO userDTO, ApplicationUser user);

        public Comment MapToComment(CommentRequestDTO commentRequestDTO);

        // Map to DTOs
        public UserResponseDTO MapToResponseUserDTO(ApplicationUser user, string userType);

        public RatingResponseDTO MapToRatingResponseDTO(Rating rating);

        public StudentCoursesResponseDTO MapToStudentCoursesResponseDTO(StudentCourses studentCourses);

        public StudentResponseDTO MapToStudentResponseDTO(Student student);

        public TeacherResponseDTO MapToTeacherResponseDTO(Teacher teacher);

        public LectureResponseDTO MapToLectureResponseDTO(Lecture lecture);

        public CourseResponseDTO MapToCourseResponseDTO(Course course);

        public CommentResponseDTO MapToCommentResponseDTO(Comment comment);
    }
}
