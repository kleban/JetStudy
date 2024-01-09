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
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {

        public CourseRepository(JetStudyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>> GetCoursesByUserId(Guid id)
        {
            return await Context.Courses.Where(x => x.OwnerId == id).ToListAsync();
        }
    }
}
