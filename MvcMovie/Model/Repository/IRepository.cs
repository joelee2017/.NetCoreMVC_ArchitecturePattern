using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Model.Models
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
