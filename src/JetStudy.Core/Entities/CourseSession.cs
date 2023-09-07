﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Core.Entities
{
    public class CourseSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public CourseSessionStatus Status { get; set; }

        [ForeignKey(nameof(CourseSessionStatus))]
        public int StatusId { get; set; }

        public CourseSessionType Type { get; set; }

        [ForeignKey(nameof(CourseSessionType))]
        public int TypeId { get; set; }

        public Course Course { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<ParticipationRecord> ParticipationRecords { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}