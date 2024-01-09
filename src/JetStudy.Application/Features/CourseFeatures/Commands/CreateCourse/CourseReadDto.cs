using JetStudy.Application.Features.UserFeatures;
using JetStudy.Domain.Common;
using JetStudy.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse
{
    public class CourseReadDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? DetailedDesc { get; set; }
        public string? ShortDesc { get; set; }
        public string? Requirements { get; set; }
        public string? CoverPath { get; set; } 
        [NotMapped]
        public IFormFile? CoverFile { get; set; }
        public UserReadShortDto? Owner { get; set; }
    }
}
