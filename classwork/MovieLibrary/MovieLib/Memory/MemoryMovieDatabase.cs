using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase
    {
        public string Add ( Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                return "Movie cannot be null";
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return "Movie is invalid";

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique";

            //Add
            _movies.Add(movie);
            return "";
        }

        private Movie FindByName ( string name )
        {
            //Foreach rules
            // 1. loop variant is readonly
            // 2. Array cannot change
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
                    return movie;

            return null;
        }

        public void Delete ( Movie movie )
        { }

        public Movie Get ()
        {
            return null;
        }

        public Movie[] GetAll()
        {
            //TODO: Broken
            return _movies.ToArray();
        }

        public void Update ( Movie movie )
        { }

        private readonly List<Movie> _movies = new List<Movie>();
    }
}
