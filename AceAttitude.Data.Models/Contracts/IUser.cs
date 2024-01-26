using AceAttitude.Data.Models.Contracts.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceAttitude.Data.Models.Contracts
{
    public interface IUser : IsCreatable, IsDeletable, IsModifiable
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }   


    }
}
