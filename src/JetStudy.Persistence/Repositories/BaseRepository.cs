using JetStudy.Application.Repositories;
using JetStudy.Domain.Common;
using JetStudy.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetStudy.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity
    {
        protected readonly JetStudyContext Context;

        public BaseRepository(JetStudyContext context)
        {
            Context = context;
        }

        public async Task<Guid> CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            await Context.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Remove(entity);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }

}
