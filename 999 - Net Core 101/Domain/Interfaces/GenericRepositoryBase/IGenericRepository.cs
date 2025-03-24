using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Domain.Interfaces.Entity;

namespace Domain.Interfaces.GenericRepositoryBase
{
    public interface IGenericRepository<T> where T : class,IEntity,new()
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T,bool>> filter);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> filter = null);
        Task AddAsync(T entity);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task<bool> isExistAsync(Expression<Func<T,bool>> filter);
        Task SaveChangeAsync();

    }
}