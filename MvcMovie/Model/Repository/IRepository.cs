using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Model.Models
{
    public interface IRepository<TEntity, TResultMdoel> where TEntity : class
    {
        public IEnumerable<TResultMdoel> GetAll();

        public TResultMdoel Find(int id);

        public TResultMdoel FirstOrDefault(Expression<Func<TEntity, bool>> func);

        public EntityEntry<TEntity> Add(TEntity movie);

        public EntityEntry<TEntity> Update(TEntity movie);

        public EntityEntry<TEntity> Remove(TEntity movie);

        public Task<int> SaveChangesAsync();
    }
}
