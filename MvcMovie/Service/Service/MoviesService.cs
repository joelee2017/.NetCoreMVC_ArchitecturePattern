using Model.Models;
using Nelibur.ObjectMapper;
using System.Collections.Generic;
using System.Linq;
using static Models.Program;

namespace Service.Service
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

        public IQueryable<MovieViewModel> GetAll()
        {
            var tinyResult = TinyMapper.Map<IQueryable<Movie>, IQueryable<MovieViewModel>>(_movieRepository.GetAll());

            return tinyResult;
        }

        public IQueryable<MovieViewModel> Search(string movieGenre, string searchString)
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


            IQueryable<MovieViewModel> mappResult;
            try
            {
                mappResult = TinyMapper.Map<IQueryable<MovieViewModel>>(movies);
            }
            catch (System.Exception ex)
            {

                throw;
            }

            

            return mappResult;
        }
    }
}
