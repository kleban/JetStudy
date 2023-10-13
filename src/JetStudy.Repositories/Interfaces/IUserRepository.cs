using JetStudy.Core.Entities;
using JetStudy.Repositories.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Get(string id);
        Task<IEnumerable<UserReadDto>> GetAll();
        Task<string> Create(UserCreateDto obj);
        Task Update(UserUpdateDto obj, string[] roles);
        Task<IEnumerable<string>> GetRoles();
        void Delete(string id);

    }
}
