using JetStudy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Interfaces
{
    public interface ISessionTypeRepository: ISave
    {
        CourseSessionType Get(int id);
        IEnumerable<CourseSessionType> GetAll();
        void Add(CourseSessionType obj);
        void Update(CourseSessionType obj);
        void Delete(int id);
    }
}
