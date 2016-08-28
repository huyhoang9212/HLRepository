using HL.Core.Domain;
using HL.Core.Infrastructure;
using System;
using System.Data.Entity;
using System.Linq;

namespace HL.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IObjectState
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Delete(object id)
        {
            var entity = Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            //_dbSet.Remove(entity);
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        /// <summary>
        /// 2 ways to add entity
        /// 1: dbSet.Add(entity);
        /// 2: 
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Added;        
           // _dbSet.Add(entity);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet.AsQueryable();
        }

        public void Update(TEntity entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
