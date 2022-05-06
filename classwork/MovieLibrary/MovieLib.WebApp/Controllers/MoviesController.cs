using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MovieLib.WebApp.Models;

namespace MovieLib.WebApp.Controllers
{
    //URL: <controller>/<action>
    public class MoviesController : Controller
    {
        public MoviesController ( IMovieDatabase database )
        {
            _database = database;
        }

        //Actions
        //  public method
        //  return IActionResult or derived type
        [HttpGet]
        public IActionResult Index ()
        {
            var movies = _database.GetAll();
            var models = movies.Select(x => new MovieViewModel(x));

            return View(models); //"Index.cshtml"
            //return View("List.cshtml", models);
        }

        // movies/details/{id}
        [HttpGet]
        public IActionResult Details ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);
            return View(model);
        }

        // movies/edit/{id}
        [HttpGet]
        public IActionResult Edit ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit ( MovieViewModel model )
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var newMovie = model.ToMovie();

                _database.Update(model.Id, newMovie);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        // movies/create
        [HttpGet]
        public IActionResult Create ()
        {
            var model = new MovieViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create ( MovieViewModel model )
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var newMovie = model.ToMovie();

                _database.Add(newMovie);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        // movies/delete/{id}
        [HttpGet]
        public IActionResult Delete ( int id )
        {
            var movie = _database.Get(id);
            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete ( MovieViewModel model )
        {
            try
            {
                _database.Delete(model.Id);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        private readonly IMovieDatabase _database;
    }
}
