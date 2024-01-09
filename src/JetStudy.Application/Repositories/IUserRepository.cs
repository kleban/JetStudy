using JetStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
