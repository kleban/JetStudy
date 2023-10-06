using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Core.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public string? Photo { get; set; }
        public virtual ICollection<CourseSession> Sessions { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual ICollection<ParticipationRecord> ParticipationRecords { get; set; }
    }
}
