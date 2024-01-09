using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse
{
    public record CreateCourseCommand(string Title, Guid? OwnerId) : IRequest<CourseReadDto> { }
}
