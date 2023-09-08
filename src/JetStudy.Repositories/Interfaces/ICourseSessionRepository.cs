using JetStudy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Interfaces
{
    public interface ICourseSessionRepository : ISave
    {
        CourseSession Get(int id);
        IEnumerable<CourseSession> GetAll();
        void Add(CourseSession obj);
        void Update(CourseSession obj);
        void Delete(int id);
    }
}
