using AutoMapper;
using JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse;
using JetStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Features.CourseFeatures
{
    public sealed class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<Course, CourseReadDto>()
                .ForMember(dest => dest.Owner, act => act.MapFrom(src => src.Owner));

            CreateMap<Course, CourseReadShortDto>();
        }
    }
}
