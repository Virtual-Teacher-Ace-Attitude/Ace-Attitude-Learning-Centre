using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;
using AceAttitude.Web.DTO.Response;

namespace AceAttitude.Services.Mapping.Contracts
{
    public interface IModelMapper
    {
        public Student MapToStudentLite(ApplicationUser user);

        public Teacher MapToTeacherLite(ApplicationUser user);

        public Student MapToStudent(ApplicationUser user);

        public Teacher MapToTeacher(ApplicationUser user);

        public ApplicationUser MapToUser(UserRegisterRequestDTO userDTO, string passwordHash);

        public UserResponseDTO MapToResponseUserDTO(ApplicationUser user, string userType);

        public StudentResponseDTO MapToStudentResponseDTO(Student student);

        public TeacherResponseDTO MapToTeacherResponseDTO(Teacher teacher);
    }
}
