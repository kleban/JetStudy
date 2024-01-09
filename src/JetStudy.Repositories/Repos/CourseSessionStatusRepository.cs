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
    public class SessionStatusRepository : ISessionStatusRepository
    {
        private JetStudyContext _context;

        public SessionStatusRepository(JetStudyContext context)
        {
            _context = context;
        }

        public void Add(CourseSessionStatus obj)
        {
           // _context.Courses.Add(obj);
           // Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseSessionStatus Get(int id)
        {
            return null;
            //return _context.Courses.Include(x=> x.Sessions).ThenInclude(x=> x.Status).First(x=> x.Id == id);
        }

        public IEnumerable<CourseSessionStatus> GetAll()
        {
            return _context.CourseSessionStatuses.ToList();
        }

        public void Save()
        {
            _context.SaveChanges(); ;
        }

        public void Update(CourseSessionStatus obj)
        {
            //_context.Courses.Update(obj);
        }
    }


}
