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
            movie.Id = _id++;
            _movies.Add(movie.Copy());
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

        public void Delete ( int id )
        {
            //Find by movie.Id;
            foreach (var item in _movies)
            {
                if (item.Id == id)
                {
                    _movies.Remove(item);
                    return;
                };
            };
        }

        public Movie Get ( int id )
        {
            //var movie = FindById(id);
            //return movie?.Copy();
            return FindById(id)?.Copy();
        }

        private Movie FindById ( int id )
        {
            foreach (var item in _movies)
            {
                if (item.Id == id)
                    return item;
            };

            return null;
        }

        public Movie[] GetAll()
        {
            //Need to clone movies so changes outside database do not impact our copy
            //return _movies.ToArray();
            var items = new Movie[_movies.Count];
            var index = 0;
            foreach (var movie in _movies)
                items[index++] = movie.Copy();

            return items;
        }

        public string Update ( int id, Movie movie )
        {
            //TODO: Validate
            if (id <= 0)
                return "Id must be greater than or equal to 0";
            if (movie == null)
                return "Movie cannot be null";
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return error;

            //Title must be unique or same movie
            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                return "Movie must be unique";

            //Make sure movie already exists
            existing = FindById(id);
            if (existing == null)
                return "Movie does not exist";

            //Update            
            existing.CopyFrom(movie);
            return "";
        }

        private readonly List<Movie> _movies = new List<Movie>();

        //Simple identifier system
        private int _id = 1;
    }
}
