using JetStudy.Domain.Context;
using JetStudy.Domain.Entities;
using JetStudy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Repos
{
    public class SessionTypeRepository : ISessionTypeRepository
    {
        private JetStudyContext _context;

        public SessionTypeRepository(JetStudyContext context)
        {
            _context = context;
        }

        public void Add(CourseSessionType obj)
        {
           // _context.Courses.Add(obj);
           // Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseSessionType Get(int id)
        {
            return null;
            //return _context.Courses.Include(x=> x.Sessions).ThenInclude(x=> x.Status).First(x=> x.Id == id);
        }

        public IEnumerable<CourseSessionType> GetAll()
        {
            return _context.CourseSessionTypes.ToList();
        }

        public void Save()
        {
            _context.SaveChanges(); ;
        }

        public void Update(CourseSessionType obj)
        {
            //_context.Courses.Update(obj);
        }
    }


}
