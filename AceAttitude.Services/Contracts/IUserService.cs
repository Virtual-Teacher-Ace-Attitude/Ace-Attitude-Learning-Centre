

using AceAttitude.Data.Models;
using AceAttitude.Web.DTO.Request;

namespace AceAttitude.Services.Contracts
{
    public interface IUserService
    {
        public ApplicationUser GetById(string id);

        public Student GetStudentById(string id);

        public Teacher GetTeacherById(string id);

        public ApplicationUser Create(ApplicationUser user);

        public ApplicationUser CreateTeacher(ApplicationUser user);

        public ApplicationUser CreateStudent(ApplicationUser user);

        public ApplicationUser Update(string id, ApplicationUser requestUser, ApplicationUser userToUpdate);

        public ApplicationUser Delete(string id, ApplicationUser requestUser);

        public void CheckEmailExists(string email);

        public ApplicationUser GetByEmail(string email);

        public Teacher ViewTeacherProfile(string id, ApplicationUser requestUser);

        public Student ViewStudentProfile(string id, ApplicationUser requestUser);

        public Student ApplyForTeacher(ApplicationUser requestUser);

        public ICollection<Teacher> GetUnapprovedTeachers(ApplicationUser requestUser);

        public ICollection<Student> GetUnapprovedStudents(ApplicationUser requestUser);

        public Teacher ApproveTeacher(string id, ApplicationUser requestUser);

        public Teacher PromoteStudent(string id, ApplicationUser requestUser);

        public Teacher PromoteAdmin(string id, ApplicationUser requestUser);
    }
}
