using AceAttitude.Data.Models;

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

        ApplicationUser Update(string id, ApplicationUser user);

        ApplicationUser Delete(string id);

        ApplicationUser CreateTeacher(ApplicationUser user);

        ApplicationUser CreateStudent(ApplicationUser user);

        Teacher ApproveTeacher(string id);

        Teacher PromoteAdmin(string id);

        public bool CheckEmailExists(string email);
    }
}
