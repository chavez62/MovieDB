using Microsoft.AspNetCore.Mvc;
using MovieDB.Services;

namespace MovieDB.Controllers
{
    public class MoviesController : Controller
    {
        private readonly TmdbClient _tmdbClient;

        public MoviesController(TmdbClient tmdbClient)
        {
            _tmdbClient = tmdbClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var movies = await _tmdbClient.GetNowPlayingMoviesAsync();
                return View(movies);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var movie = await _tmdbClient.GetMovieDetailsAsync(id);
                return View(movie);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public async Task<IActionResult> Popular(int page = 1)
        {
            try
            {
                var movies = await _tmdbClient.GetPopularMoviesAsync(page: page);
                return View(movies);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}