using JetStudy.Core.Entities;
using JetStudy.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace JetStudy.WebApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository courseRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CourseController(ICourseRepository courseRepository, 
            IWebHostEnvironment webHostEnvironment)
        {
            this.courseRepository = courseRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(courseRepository.GetAll());
        }

        /*public string Image(int id)
        {
            var course = courseRepository.Get(id);
            return course.CoverPath;
        }*/

        public IActionResult Create() 
        {
            return View(new Course());
        }

        [HttpPost]
        public IActionResult Create(Course model)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Path.GetFileNameWithoutExtension(model.CoverFile.FileName); 
                
                string extension = Path.GetExtension(model.CoverFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;                
                model.CoverPath = "/img/course/" + fileName;
                string path = Path.Combine(wwwRootPath + "/img/course/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    model.CoverFile.CopyTo(fileStream);
                }

                courseRepository.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            return View(courseRepository.Get(id));
        }
    }
}
