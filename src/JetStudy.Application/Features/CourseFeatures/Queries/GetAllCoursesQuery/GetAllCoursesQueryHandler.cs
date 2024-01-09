using AutoMapper;
using JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse;
using JetStudy.Application.Repositories;
using JetStudy.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Features.CourseFeatures.Queries.GetAllCourse
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseReadShortDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public GetAllCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseReadShortDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return _mapper.Map<IEnumerable<Course>, IEnumerable<CourseReadShortDto>>(await _courseRepository.GetAllAsync());
        }
    }
}
