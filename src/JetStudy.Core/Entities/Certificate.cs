using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Core.Entities
{
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Path { get; set; }
        public string VefificationCode { get;set; }
        public ParticipationRecord ParticipationRecord { get; set; }

        [ForeignKey(nameof(ParticipationRecord))]
        public int ParticipationRecordId { get; set; }
    }
}
