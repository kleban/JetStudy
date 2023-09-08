using JetStudy.Core.Entities;
using JetStudy.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JetStudy.WebApp.Controllers
{
    public class SessionController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly ICourseSessionRepository sessionRepository;
        private readonly ISessionStatusRepository sessionStatusRepository;
        private readonly ISessionTypeRepository sessionTypeRepository;

        public SessionController(ICourseSessionRepository sessionRepository,
            ISessionStatusRepository statusRepository,
            ISessionTypeRepository typeRepository,
            ICourseRepository courseRepository)
        {
            this.sessionRepository = sessionRepository;
            this.sessionStatusRepository = statusRepository;
            this.sessionTypeRepository = typeRepository;
            this.courseRepository = courseRepository;

        }

        public IActionResult Create(int courseId)
        {
            ViewBag.CourseTitle = courseRepository.Get(courseId).Title;
           var types = sessionTypeRepository.GetAll()
                .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();
            ViewBag.Types = types;
            return View(new CourseSession { CourseId = courseId, StatusId = 1 });
        }

        [HttpPost]
        public IActionResult Create(CourseSession session)
        {
            if(ModelState.IsValid)
            {
                sessionRepository.Add(session);
                return RedirectToAction("Details", "Course", new { id = session.CourseId });
            }

            return View(session);
        }
    }
}
