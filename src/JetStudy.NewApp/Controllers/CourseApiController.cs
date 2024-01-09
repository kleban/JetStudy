using JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse;
using JetStudy.Application.Features.CourseFeatures.Queries.GetAllCourse;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetStudy.NewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseReadShortDto>> GetAsync()
        {
            var courses = await _mediator.Send(new GetAllCoursesQuery());
            return courses;
        }
    }
}
