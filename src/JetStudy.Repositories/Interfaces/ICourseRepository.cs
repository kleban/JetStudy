using JetStudy.Domain.Entities;
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
        IEnumerable<Course> GetAll(string? username = null);
        void Add(Course obj, string username);
        void Update(Course obj);
        void Delete(int id);
    }
}
