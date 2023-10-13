using JetStudy.Repositories.DTOs.User;
using JetStudy.Repositories.Interfaces;
using JetStudy.Repositories.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JetStudy.WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await userRepository.GetAll());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new UserCreateDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var userId = await userRepository.Create(model);
                return RedirectToAction("Edit", new { id = userId });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Roles = await userRepository.GetRoles();
            var userUpdate = await userRepository.Get(id);           
            return View(userUpdate);
        }

         [HttpPost]
         [AutoValidateAntiforgeryToken]
         public async Task<IActionResult> Edit(UserDto model, string[] roles)
         {
             if (ModelState.IsValid)
             {
                 await userRepository.Update(model, roles);
                 return RedirectToAction("Index");
             }
             ViewBag.Roles = await userRepository.GetRoles();
             return View(model);
         }
    }
}
