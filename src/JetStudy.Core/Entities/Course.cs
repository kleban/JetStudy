using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Core.Entities
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string DetailedDesc { get; set; }
        public string ShortDesc { get; set; }
        public string Requirements { get; set; }
        //public string Path { get; set; }
        public virtual ICollection<CourseSession> Sessions { get; set; }
    }
}
