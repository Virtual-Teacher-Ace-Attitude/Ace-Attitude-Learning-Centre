

using AceAttitude.Data.Models;

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

        public ApplicationUser Update(string id, ApplicationUser user);

        public ApplicationUser Delete(string id);

        public void CheckEmailExists(string email);

        public ApplicationUser GetByEmail(string email);

        public Teacher ViewTeacherProfile(string id, ApplicationUser requestUser);

        public Student ViewStudentProfile(string id, ApplicationUser requestUser);

        public ICollection<Teacher> GetUnapprovedTeachers(ApplicationUser requestUser);
    }
}
