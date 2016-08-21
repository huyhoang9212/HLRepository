using HL.Core.Infrastructure;
using System;
using System.Data.Entity;
using System.Linq;

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
            _dbSet.Remove(entity);
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet.AsQueryable();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
