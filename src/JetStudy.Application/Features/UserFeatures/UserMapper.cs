using AutoMapper;
using JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse;
using JetStudy.Application.Features.UserFeatures;
using JetStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Features.CourseFeatures
{
    public sealed class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserReadShortDto>()
                .ForMember(dest => dest.FullName, act => act.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.OwnCoursesCount, act => act.MapFrom(src => src.Courses.Count()));
        }
    }
}
