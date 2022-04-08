using System.Collections.Generic;

namespace MovieLib
{
    /// <summary>Represents a movie database.</summary>
    public interface IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>        
        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">Movie is not unique.</exception>
        string Add ( Movie movie );

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to 0.</exception>
        string Delete ( int id );

        /// <summary>Gets a movie, if any.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>The movie, if any.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to 0.</exception>
        Movie Get ( int id );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies.</returns>
        IEnumerable<Movie> GetAll ();

        /// <summary>Updates a movie in the database.</summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="movie">The movie details.</param>        
        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to 0.</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">Movie is not unique.</exception>
        string Update ( int id, Movie movie );
    }
}