using JetStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Application.Repositories
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesByUserId(Guid id);
    }
}
