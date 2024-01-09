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
        Task<UserDto> GetAsync(string id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<string> CreateAsync(UserCreateDto obj);
        Task UpdateAsync(UserDto obj, string[] roles);
        Task<IEnumerable<string>> GetRolesAsync();
        Task DeleteAsync(string id);

    }
}
