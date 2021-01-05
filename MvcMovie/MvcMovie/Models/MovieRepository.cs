using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MvcMovie.Data;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieRepository
    {
        private readonly MvcMovieContext _mvcMovieContext;

        public MovieRepository(MvcMovieContext mvcMovieContext)
        {
            _mvcMovieContext = mvcMovieContext;
        }

        public DbSet<Movie> Movie => _mvcMovieContext.Movie;

        public EntityEntry<Movie> Add(Movie movie) => _mvcMovieContext.Add(movie);

        public EntityEntry<Movie> Update(Movie movie) => _mvcMovieContext.Update(movie);

        public EntityEntry<Movie> Remove(Movie movie) => _mvcMovieContext.Remove(movie);

        public Task<int> SaveChangesAsync() => _mvcMovieContext.SaveChangesAsync();
    }
}
