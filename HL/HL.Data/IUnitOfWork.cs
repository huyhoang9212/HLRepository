using HL.Core.Infrastructure;
using System;

namespace HL.Data
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
    }
}
