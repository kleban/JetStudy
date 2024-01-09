using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetStudy.Domain.Common;

namespace JetStudy.Application.Repositories
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task<Guid> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task SaveAsync();
    }
}
