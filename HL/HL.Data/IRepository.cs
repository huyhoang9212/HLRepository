using System;
using HL.Core.Infrastructure;

namespace HL.Data
{
    public interface IRepository<TEntity> where TEntity : class, IObjectState
    {
        TEntity Find(params object[] keyValues);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(object id);
    }
}
