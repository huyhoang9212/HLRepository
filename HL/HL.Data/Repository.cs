using HL.Core.Infrastructure;
using System;
using System.Data.Entity;

namespace HL.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IObjectState
    {
        private readonly NorthwindContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(NorthwindContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            
        }
    }
}
