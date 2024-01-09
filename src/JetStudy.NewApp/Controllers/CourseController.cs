using JetStudy.Application.Features.CourseFeatures.Commands.CreateCourse;
using JetStudy.Application.Features.CourseFeatures.Queries.GetAllCourse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JetStudy.NewApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _mediator.Send(new GetAllCoursesQuery());
            return View(courses);
        }
    }
}
