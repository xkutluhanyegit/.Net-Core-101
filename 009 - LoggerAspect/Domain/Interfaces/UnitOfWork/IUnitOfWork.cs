using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Entity;
using Domain.Interfaces.GenericRepositoryBase;

namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class, IEntity, new();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void BeginTransaction();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        void DisposeTransaction();
        Task DisposeTransactionAsync();
    }
}