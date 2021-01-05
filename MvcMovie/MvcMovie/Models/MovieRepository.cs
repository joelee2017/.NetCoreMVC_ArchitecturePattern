using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MvcMovie.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MvcMovieContext _mvcMovieContext;

        public MovieRepository(MvcMovieContext mvcMovieContext) => _mvcMovieContext = mvcMovieContext;

        public DbSet<Movie> GetAll() => _mvcMovieContext.Movie;

        public ValueTask<Movie> FindAsync(int id) => _mvcMovieContext.Movie.FindAsync(id);

        public Task<Movie> FirstOrDefaultAsync(Expression<Func<Movie, bool>> func) 
            => _mvcMovieContext.Movie.FirstOrDefaultAsync(func);
            

        public EntityEntry<Movie> Add(Movie movie) => _mvcMovieContext.Add(movie);

        public EntityEntry<Movie> Update(Movie movie) => _mvcMovieContext.Update(movie);

        public EntityEntry<Movie> Remove(Movie movie) => _mvcMovieContext.Remove(movie);

        public Task<int> SaveChangesAsync() => _mvcMovieContext.SaveChangesAsync();
    }
}
