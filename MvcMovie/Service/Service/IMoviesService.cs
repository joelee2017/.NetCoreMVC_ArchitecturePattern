using Model.Models;
using System.Linq;

namespace Service.Service
{
    public interface IMoviesService
    {
        public IQueryable<string> GenreQuery();

        public IQueryable<MovieViewModel> Search(string movieGenre, string searchString);

        public IQueryable<MovieViewModel> GetAll();
    }
}
