using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        ApplicationUser GetById(string id);

        Student GetStudentById(string id);

        Teacher GetTeacherById(string id);

        ApplicationUser GetByEmail(string email);

        ICollection<Teacher> GetUnapprovedTeachers();

        ApplicationUser Create(ApplicationUser user);

        ApplicationUser Update(string id, UserUpdateRequestDTO userUpdateRequestDTO);

        ApplicationUser Delete(string id);

        ApplicationUser CreateTeacher(ApplicationUser user);

        ApplicationUser CreateStudent(ApplicationUser user);

        Teacher ApproveTeacher(string id);

        Teacher PromoteAdmin(string id);

        public bool CheckEmailExists(string email);
    }
}
