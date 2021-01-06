using MvcMovie.Models;
using System.Linq;

namespace MvcMovie.Service
{
    public interface IMoviesService
    {
        public IQueryable<string> GenreQuery();

        public IQueryable<Movie> Search(string movieGenre, string searchString);
    }
}
