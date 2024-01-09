using JetStudy.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Domain.Entities
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public DateTime? DateOfBirth { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public string? Photo { get; set; }
        public virtual ICollection<Course>? Courses { get; set; } = new HashSet<Course>();
    }
}
