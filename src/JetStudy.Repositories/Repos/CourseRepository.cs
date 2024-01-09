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
    public class CourseRepository : ICourseRepository
    {
        private JetStudyContext _context;

        public CourseRepository(JetStudyContext context)
        {
            _context = context;
        }

        public void Add(Course obj, string username)
        {
            obj.Owner = _context.Users.First(x => x.UserName == username);
            _context.Courses.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Course Get(int id)
        {
            return _context.Courses
                .Include(x=> x.Sessions)
                .ThenInclude(x=> x.Status)
                .Include(x => x.Sessions)
                .ThenInclude(x=> x.Type).First(x=> x.Id == id);
        }

        public IEnumerable<Course> GetAll(string? username = null)
        {
            if(username is null)
                return _context.Courses.Include(x=> x.Owner).ToList();

            return _context.Courses
                .Include(x => x.Owner)
                .Where(x => x.Owner.UserName == username).ToList();
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
