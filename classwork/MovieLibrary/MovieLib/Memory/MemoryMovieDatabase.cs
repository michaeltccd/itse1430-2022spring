using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLib.Memory
{
    /// <summary>Provides an in-memory movie database.</summary>
    public class MemoryMovieDatabase : IMovieDatabase
    {
        //Not visible in interface
        public void Foo () { }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The error message, if any.</returns>
        /// <remarks>
        /// Errors occur if:
        /// <paramref name="movie"/> is null.
        /// <paramref name="movie"/> is not valid.
        /// A movie with the same title already exists.
        /// </remarks>
        public string Add ( Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                return "Movie cannot be null";

            //TODO: Fix validation message
            if (!new ObjectValidator().TryValidateObject(movie, out var errors))
                return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return "Movie is invalid";

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique";

            //Add
            movie.Id = _id++;
            _movies.Add(movie.Copy());
            return "";
        }

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The ID of the movie to delete.</param>
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

        /// <summary>Gets a movie.</summary>
        /// <param name="id">The ID of the movie to get.</param>
        /// <returns>The movie, if found.</returns>
        public Movie Get ( int id )
        {
            //var movie = FindById(id);
            //return movie?.Copy();
            return FindById(id)?.Copy();
        }

        //Iterators - implementation of IEnumerable<T>
        // Defer executes the method such that the method is called piecemeal on demand

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies in the database.</returns>
        public IEnumerable<Movie> GetAll ()
        {
            //Need to clone movies so changes outside database do not impact our copy
            //return _movies.ToArray();
            //var items = new Movie[_movies.Count];
            //var index = 0;
            foreach (var movie in _movies)
            {
                //System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");
                //items[index++] = movie.Copy();
                yield return movie.Copy();
            };

            //return items;
        }

        /// <summary>Updates an existing movie in the database.</summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="movie">The updated movie.</param>
        /// <returns>The error message, if any.</returns>
        /// <remarks>
        /// Errors occur if:
        /// <paramref name="id"/> is less than or equal to zero.
        /// <paramref name="movie"/> is null.
        /// <paramref name="movie"/> is not valid.     
        /// A movie with the same title already exists.
        /// The movie cannot be found.
        /// </remarks>
        public string Update ( int id, Movie movie )
        {
            //TODO: Validate
            if (id <= 0)
                return "Id must be greater than or equal to 0";
            if (movie == null)
                return "Movie cannot be null";

            if (!new ObjectValidator().TryValidateObject(movie, out var errors))
                return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //  return error;

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

        #region Private Members

        private Movie FindById ( int id )
        {
            foreach (var item in _movies)
            {
                if (item.Id == id)
                    return item;
            };

            return null;
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

        private readonly List<Movie> _movies = new List<Movie>();

        //Simple identifier system
        private int _id = 1;
        #endregion
    }
}
