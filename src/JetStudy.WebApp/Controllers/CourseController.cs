using JetStudy.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JetStudy.WebApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            return View(courseRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(courseRepository.Get(id));
        }
    }
}
