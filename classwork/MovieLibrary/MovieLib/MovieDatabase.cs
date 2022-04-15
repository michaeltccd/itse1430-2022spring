using System;
using System.Collections.Generic;

namespace MovieLib
{
    /// <summary>Provides a base implementation of <see cref="IMovieDatabase"/>.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The error message, if any.</returns>
        /// <remarks>
        /// Errors occur if:
        /// <paramref name="movie"/> is null.
        /// <paramref name="movie"/> is not valid.
        /// A movie with the same title already exists.
        /// </remarks>
        public Movie Add ( Movie movie )
        {
            //Raise an error using throw
            //   throw-statement ::= throw E(exception)

            // Validate
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            //movie = movie ?? throw new ArgumentNullException(nameof(movie));

            //return "Movie cannot be null";

            //Throw ValidationException if anything wrong
            ObjectValidator.ValidateObject(movie);
            //if (!ObjectValidator.TryValidateObject(movie, out var errors))
            //    return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return "Movie is invalid";

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                //return "Movie must be unique";
                //throw new InvalidOperationException("Movie must be unique");
                throw new ArgumentException("Movie must be unique", nameof(movie));

            //Add
            var newMovie = AddCore(movie);
            //movie.Id = newMovie.Id;
            //return "";
            return newMovie;
        }

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie.</returns>
        protected abstract Movie AddCore ( Movie movie );

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The ID of the movie to delete.</param>
        public void Delete ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");
                //return "ID must be > 0";

            DeleteCore(id);        
        }

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The ID of the movie to delete.</param>
        protected abstract void DeleteCore ( int id );

        /// <summary>Gets a movie.</summary>
        /// <param name="id">The ID of the movie to get.</param>
        /// <returns>The movie, if found.</returns>
        public Movie Get ( int id )
        {
            //if (id <= 0)
            //    return null;
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");

            return GetCore(id);
        }

        /// <summary>Gets a movie.</summary>
        /// <param name="id">The ID of the movie to get.</param>
        /// <returns>The movie, if found.</returns>
        protected abstract Movie GetCore ( int id );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies in the database.</returns>
        public IEnumerable<Movie> GetAll () => GetAllCore();

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies in the database.</returns>
        protected abstract IEnumerable<Movie> GetAllCore ();

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
        public void Update ( int id, Movie movie )
        {
            //TODO: Validate
            if (id <= 0)
            //return "Id must be greater than or equal to 0";            
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");
            if (movie == null)
                //return "Movie cannot be null";
                throw new ArgumentNullException(nameof(movie));

            ObjectValidator.ValidateObject(movie);
            //if (!ObjectValidator.TryValidateObject(movie, out var errors))
            //    return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //  return error;

            //Title must be unique or same movie
            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                //return "Movie must be unique";
                throw new ArgumentException("Movie must be unique", nameof(movie));

            //Make sure movie already exists
            existing = GetCore(id);
            if (existing == null)
                //return "Movie does not exist";
                throw new ArgumentException("Movie does not exist", nameof(movie));

            //Update            
            UpdateCore(id, movie);
            //return "";
        }

        /// <summary>Updates a movie.</summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="movie">The movie details.</param>
        protected abstract void UpdateCore ( int id, Movie movie );

        /// <summary>Finds a movie by name.</summary>
        /// <param name="name">The movie name.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie FindByName ( string name );
    }
}
