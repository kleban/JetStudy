using JetStudy.Core.Context;
using JetStudy.Core.Entities;
using JetStudy.Repositories.DTOs.User;
using JetStudy.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Repos
{
    public class UserRepository : IUserRepository
    {
        private JetStudyContext _context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRepository(JetStudyContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = context;
        }

        public async Task<string> Create(UserCreateDto obj)
        {
            var newUser = new User
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                UserName = obj.Email,
                NormalizedEmail = obj.Email.ToUpper(),
                NormalizedUserName = obj.Email.ToUpper(),
                EmailConfirmed = true               
            };

            await userManager.CreateAsync(newUser, obj.Password);

            return _context.Users.First(x=> x.Email == obj.Email).Id;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> Get(string id)
        {
            var all = await GetAll();
            return all.First(x => x.Id == id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = _context.Users.ToList();
            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                usersDto.Add(
                    new UserDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        IsConfirmed = user.EmailConfirmed,
                        Roles = roles.ToList()
                    });
            }

            return usersDto;
        }

        public async Task Update(UserDto model, string[] roles)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (user.Email != model.Email)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.NormalizedUserName = model.Email.ToUpper();
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if (user.FirstName != model.FirstName)   user.FirstName = model.FirstName;
            if (user.LastName != model.LastName)   user.LastName = model.LastName;
            if (user.EmailConfirmed != model.IsConfirmed) user.EmailConfirmed = model.IsConfirmed;

            if ((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }

            if (roles.Any())
            {
                await userManager.AddToRolesAsync(user, roles.ToList());
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<string?>> GetRoles()
        {
            return _context.Roles.Select(x => x.Name).ToList();
        }
    }
}
