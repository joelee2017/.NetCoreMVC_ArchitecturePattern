using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.Service
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MoviesService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IQueryable<string> GenreQuery()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _movieRepository.GetAll()
                                            orderby m.Genre
                                            select m.Genre;

          
            return genreQuery.Distinct();
        }

        public IQueryable<Movie> GetAll() => _movieRepository.GetAll();

        public IQueryable<Movie> Search(string movieGenre, string searchString)
        {
            var movies = from m in _movieRepository.GetAll()
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return movies;
        }
    }
}
