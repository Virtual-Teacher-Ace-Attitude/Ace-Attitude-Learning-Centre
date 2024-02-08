using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Data.Repositories.Contracts
{
    public interface IUserRepository
    {
        public ApplicationUser GetById(string id);

        public Student GetStudentById(string id);

        public Teacher GetTeacherById(string id);

        public ApplicationUser GetByEmail(string email);

        public ICollection<Teacher> GetUnapprovedTeachers();

        public ICollection<Student> GetUnapprovedStudents();

        public ApplicationUser Create(ApplicationUser user);

        public ApplicationUser Update(string id, ApplicationUser userToUpdate);

        public ApplicationUser Delete(string id);

        public ApplicationUser CreateTeacher(ApplicationUser user);

        public ApplicationUser CreateStudent(ApplicationUser user);

        public Student ApplyForTeacher(string id);

        public Teacher ApproveTeacher(string id);

        public Teacher PromoteStudent(string id);

        public Teacher PromoteAdmin(string id);

        public bool CheckEmailExists(string email);
    }
}
