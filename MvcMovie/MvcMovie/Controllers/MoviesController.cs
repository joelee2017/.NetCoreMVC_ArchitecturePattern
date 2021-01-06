using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Repository;
using MvcMovie.Service;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMoviesService _moviesService;

        public MoviesController(IRepository<Movie> movieRepository, IMoviesService moviesService)
        {
            _movieRepository = movieRepository;
            _moviesService = moviesService;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            //IQueryable<string> genreQuery = from m in _movieRepository.GetAll()
            //                                orderby m.Genre
            //                                select m.Genre;

            //var movies = from m in _movieRepository.GetAll()
            //             select m;

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    movies = movies.Where(s => s.Title.Contains(searchString));
            //}

            //if (!string.IsNullOrEmpty(movieGenre))
            //{
            //    movies = movies.Where(x => x.Genre == movieGenre);
            //}

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await _moviesService.GenreQuery().ToListAsync()),
                Movies = await _moviesService.Search(movieGenre, searchString).ToListAsync()
            };

            return View(movieGenreVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.GetAll()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Add(movie);
                await _movieRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.FindAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _movieRepository.Update(movie);
                    await _movieRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _movieRepository.FindAsync(id);
            _movieRepository.Remove(movie);
            await _movieRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _movieRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
