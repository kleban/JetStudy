using AutoMapper;
using JetStudy.Application.Repositories;
using JetStudy.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseReadDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CreateCourseCommandHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<CourseReadDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var id = await _courseRepository.CreateAsync(new Course
            {
                Title = request.Title,
                OwnerId = request.OwnerId
            });

            var course = await _courseRepository.GetAsync(id);
            return _mapper.Map<Course, CourseReadDto>(course);
        }
    }
}
