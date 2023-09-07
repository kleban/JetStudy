using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Core.Entities
{
    public class ParticipationRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Student Student { get; set; }
        public ParticipationRecordStatus Status { get; set; }
        public Certificate Certificate { get; set; }
        public CourseSession CourseSession { get; set; }

        [ForeignKey(nameof(Certificate))]
        public int CertificateId { get; set; }
    }
}
