using eTicket.Data;
using eTicket.Data.Services;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    public class MoviesController : Controller 
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            //var data = await _service.Movies.Include(x=>x.Cinema).OrderBy(x=>x.Name).ToListAsync();
            var data = await _service.GetAllAsync(n=> n.Cinema);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            //var data = await _service.Movies.Include(x=>x.Cinema).OrderBy(x=>x.Name).ToListAsync();
            var data = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index",data);
        } 

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValue();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas,"Id","Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers,"Id","FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors,"Id","FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel movie)
        {
            
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValue();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails == null)
            {
                return View("NotFound"); 

            }
            return View(producersDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviesDetails = await _service.GetByIdAsync(id);
            if (moviesDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var moviesDetails = await _service.GetMovieByIdAsync(id);
            if (moviesDetails == null)
            {
                return View("NotFound");
            }

            var response = new MovieViewModel()
            {
                Id = moviesDetails.Id,
                Name = moviesDetails.Name,
                Description = moviesDetails.Description,
                Price = moviesDetails.Price,
                ImageURL = moviesDetails.ImageURL,
                StartDate = moviesDetails.StartDate,
                EndDate = moviesDetails.EndDate,
                MovieCategory = moviesDetails.MovieCategory,
                CinemaId = moviesDetails.CinemaId,
                ProducerId = moviesDetails.ProducerId,
                ActorIds = moviesDetails.Actors_Movies.Select(x => x.ActorId).ToList(),
            };


            var movieDropdownsData = await _service.GetNewMovieDropdownsValue();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieViewModel movie)
        {

            if (id!=movie.Id)
            {
                return View("Not Found");
            }

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValue();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }
            

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var moviesDetails = await _service.GetMovieByIdAsync(id);
            if (moviesDetails == null)
            {
                return View("NotFound");
            }
            return View(moviesDetails);
        }
    }
}
