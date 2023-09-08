using JetStudy.Core.Context;
using JetStudy.Core.Entities;
using JetStudy.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Repositories.Repos
{
    public class CourseSessionRepository : ICourseSessionRepository
    {
        private JetStudyContext _context;

        public CourseSessionRepository(JetStudyContext context)
        {
            _context = context;
        }

        public void Add(CourseSession obj)
        {
            _context.CourseSessions.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseSession Get(int id)
        {
            return _context.CourseSessions
                .Include(x=> x.Lessons)
                .Include(x=> x.Instructors).First(x=> x.Id == id);
        }

        public IEnumerable<CourseSession> GetAll()
        {
            return _context.CourseSessions.ToList();
        }

        public void Save()
        {
            _context.SaveChanges(); ;
        }

        public void Update(CourseSession obj)
        {
            _context.CourseSessions.Update(obj);
        }
    }


}
