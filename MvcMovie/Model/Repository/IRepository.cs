using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Model.Models
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public DbSet<TEntity> GetAll();

        public ValueTask<TEntity> FindAsync(int id);

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> func);

        public EntityEntry<TEntity> Add(TEntity movie);

        public EntityEntry<TEntity> Update(TEntity movie);

        public EntityEntry<TEntity> Remove(TEntity movie);

        public Task<int> SaveChangesAsync();
    }
}
