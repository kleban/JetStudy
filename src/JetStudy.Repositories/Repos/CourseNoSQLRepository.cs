using JetStudy.Core.Entities;
using JetStudy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Repos
{
    internal class CourseNoSQLRepository : ICourseRepository
    {
        //private readonly MongoDbConnection connection;

        public CourseNoSQLRepository()
        {
            
        }
        public void Add(Course obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Course Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Course obj)
        {
            throw new NotImplementedException();
        }
    }
}
