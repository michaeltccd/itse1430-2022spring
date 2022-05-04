using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MovieLib.WebApp.Models;

namespace MovieLib.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController ( IMovieDatabase database )
        {
            _database = database;
        }

        public IActionResult Index ()
        {
            var movies = _database.GetAll();
            var models = movies.Select(x => new MovieViewModel(x));

            return Json(models);
            return View();
        }

        private readonly IMovieDatabase _database;
    }
}
