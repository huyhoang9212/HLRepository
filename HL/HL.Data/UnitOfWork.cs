using System;
using System.Data.Entity;
using System.Collections;
using HL.Core.Infrastructure;

namespace HL.Data
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public abstract DbContext GetDbContext();

        private readonly Hashtable _hashRepositories;
        protected UnitOfWork()
        {
            _context = GetDbContext();
            _hashRepositories = new Hashtable();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState
        {
            var key = typeof(TEntity).Name;
            if(!this._hashRepositories.Contains(key))
            {
                var repositoryType = typeof(Repository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), this._context);
                this._hashRepositories[key] = repository;
            }

            return (IRepository<TEntity>)_hashRepositories[key];
        }


        private bool _disposed;
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this._disposed)
            {
                if(disposing)
                {
                    this._context.Dispose();
                }
            }
            this._disposed = true;
        }

        IRepository<TEntity> IUnitOfWork.Repository<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
