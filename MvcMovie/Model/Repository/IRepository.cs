using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Model.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();

        public TEntity Find(int id);

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> func);

        public TEntity Add(TEntity movie);

        public TEntity Update(TEntity movie);

        public void Remove(int id);
    }
}
