using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NollyTickets.Ng.Data;
using NollyTickets.Ng.Data.Services;
using NollyTickets.Ng.Models;

namespace NollyTickets.Ng.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesServices _service;

        public MoviesController(IMoviesServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
              
            return View(allMovies);
        }
        public async Task<IActionResult> Filter( string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index",filteredResult);
            }
            return View("Index", allMovies);
        }

        //Get: Movies/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            return View(movieDetails);
        }

       //Get: Movies/Create
       public async Task<IActionResult> Create()
        {
            var movieDropDownData = await _service.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownData = await _service.GetNewMovieDropDownValues();

                ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //Get: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            //Get the movie details
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorsIds = movieDetails.Actor_Movies.Select(n => n.ActorId).ToList(),
            };
            var movieDropDownData = await _service.GetNewMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var movieDropDownData = await _service.GetNewMovieDropDownValues();

                ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
