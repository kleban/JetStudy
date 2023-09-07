using JetStudy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Interfaces
{
    public interface ICourseRepository : ISave
    {
        Course Get(int id);
        IEnumerable<Course> GetAll();
        void Add(Course obj);
        void Update(Course obj);
        void Delete(int id);
    }
}
