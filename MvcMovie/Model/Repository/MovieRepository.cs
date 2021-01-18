using Model.Data;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Model.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MvcMovieContext _mvcMovieContext;

        public MovieRepository(MvcMovieContext mvcMovieContext) => _mvcMovieContext = mvcMovieContext;

        public IEnumerable<Movie> GetAll() => _mvcMovieContext.Movie;

        public Movie Find(int id)
        {
            var result = _mvcMovieContext.Movie.Find(id);

            return result;
        }

        public Movie FirstOrDefault(Expression<Func<Movie, bool>> func)
        {
            var moive = _mvcMovieContext.Movie.FirstOrDefault(func);

            return moive;
        }


        public Movie Add(Movie movie)
        {
            var moive = _mvcMovieContext.Add(movie);
            _mvcMovieContext.SaveChanges();
            return moive.Entity;
        }

        public Movie Update(Movie movie)
        {
            var moive = _mvcMovieContext.Update(movie);
            _mvcMovieContext.SaveChanges();
            return moive.Entity;
        }

        public void Remove(int id)
        {
            var movie = _mvcMovieContext.Movie.Find(id);
            _mvcMovieContext.Remove(movie);

            _mvcMovieContext.SaveChanges();
        }
    }
}
