﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using AceAttitude.Data.Models.Contracts.Role;
using AceAttitude.Data.Models.Contracts;

namespace AceAttitude.Data.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser, IsCreatable, IsModifiable, IsDeletable
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string? TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public string? StudentId { get; set; }

        public Student? Student { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [NotMapped]
        public bool IsModified => ModifiedOn.HasValue;

        public DateTime? DeletedOn { get; set; }

        [NotMapped]
        public bool IsDeleted => DeletedOn.HasValue;

        public string? PictureFilePath { get; set; }

        public string? NoteFilePath { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();

        //public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new HashSet<IdentityUserLogin<string>>();

        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new HashSet<IdentityUserClaim<string>>();

        //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = new HashSet<IdentityUserLogin<string>>();
    }
}