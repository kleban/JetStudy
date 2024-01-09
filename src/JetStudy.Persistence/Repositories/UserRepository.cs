using JetStudy.Application.Repositories;
using JetStudy.Domain.Entities;
using JetStudy.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(JetStudyContext context) : base(context)
        {
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }
    }
}
