using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JetStudy.Domain.Common;

namespace JetStudy.Domain.Entities
{
    public class Course : IEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? DetailedDesc { get; set; }
        public string? ShortDesc { get; set; }
        public string? Requirements { get; set; }
        public string? CoverPath { get; set; } = "\\img\\course\\no_cover.jpg";
        [NotMapped]
        public IFormFile? CoverFile { get; set; }
        public User? Owner { get; set; }
        [ForeignKey(nameof(Owner))]
        public Guid? OwnerId { get; set; }
  
    }
}
