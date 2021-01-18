using Model.Mapper;
using Model.Models;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service.Service
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MoviesService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IEnumerable<MovieViewModel> GetAll() => _movieRepository.GetAll().Map<Movie, MovieViewModel>(true);

        public MovieViewModel Add(Movie movie) => _movieRepository.Add(movie).Map<Movie, MovieViewModel>(true);

        public MovieViewModel Update(Movie movie) => _movieRepository.Update(movie).Map<Movie, MovieViewModel>(true);

        public void Remove(int id) => _movieRepository.Remove(id);

        public IEnumerable<string> GenreQuery()
        {
            // Use LINQ to get list of genres.
            IEnumerable<string> genreQuery = from m in _movieRepository.GetAll()
                                             orderby m.Genre
                                             select m.Genre;

            return genreQuery.Distinct();
        }

        public IEnumerable<MovieViewModel> Search(string movieGenre, string searchString)
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

            var result = movies.Map<Movie, MovieViewModel>(true) ?? new List<MovieViewModel>();

            return result;
        }

        public MovieViewModel Find(Expression<Func<Movie, bool>> func) => _movieRepository.FirstOrDefault(func).Map<Movie, MovieViewModel>(true);
    }
}
