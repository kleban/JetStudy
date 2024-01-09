using JetStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Interfaces
{
    public interface ISessionStatusRepository: ISave
    {
        CourseSessionStatus Get(int id);
        IEnumerable<CourseSessionStatus> GetAll();
        void Add(CourseSessionStatus obj);
        void Update(CourseSessionStatus obj);
        void Delete(int id);
    }
}
