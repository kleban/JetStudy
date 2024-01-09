using JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse;
using JetStudy.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Features.CourseFeatures.Queries.GetAllCourse
{
    public record GetAllCoursesQuery() : IRequest<IEnumerable<CourseReadShortDto>> { }
}
