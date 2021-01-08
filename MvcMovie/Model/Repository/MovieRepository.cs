using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Data;
using Model.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Model.Models
{
    public class MovieRepository : IRepository<Movie, MovieViewModel>
    {
        private readonly MvcMovieContext _mvcMovieContext;

        public MovieRepository(MvcMovieContext mvcMovieContext) => _mvcMovieContext = mvcMovieContext;

        public IEnumerable<MovieViewModel> GetAll() => _mvcMovieContext.Movie.Map<Movie, MovieViewModel>();

        public MovieViewModel Find(int id)
        {
            var result = _mvcMovieContext.Movie.Find(id).Map<Movie, MovieViewModel>(true);

            return result;
        }

        public MovieViewModel FirstOrDefault(Expression<Func<Movie, bool>> func)
        {
            var moive = _mvcMovieContext.Movie.FirstOrDefault(func);

            var result = moive.Map<Movie, MovieViewModel>(true);

            return result;
        }


        public EntityEntry<Movie> Add(Movie movie) => _mvcMovieContext.Add(movie);

        public EntityEntry<Movie> Update(Movie movie) => _mvcMovieContext.Update(movie);

        public EntityEntry<Movie> Remove(Movie movie) => _mvcMovieContext.Remove(movie);

        public Task<int> SaveChangesAsync() => _mvcMovieContext.SaveChangesAsync();
    }
}
