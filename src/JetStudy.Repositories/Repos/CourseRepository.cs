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
    public class CourseRepository : ICourseRepository
    {
        private JetStudyContext _context;

        public CourseRepository(JetStudyContext context)
        {
            _context = context;
        }

        public void Add(Course obj)
        {
            _context.Courses.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Course Get(int id)
        {
            return _context.Courses.Include(x=> x.Sessions).ThenInclude(x=> x.Status).First(x=> x.Id == id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public void Save()
        {
            _context.SaveChanges(); ;
        }

        public void Update(Course obj)
        {
            _context.Courses.Update(obj);
        }
    }


}
