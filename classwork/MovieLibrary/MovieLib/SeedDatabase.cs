using System;

using MovieLib.Memory;

namespace MovieLib
{
    //Static classes contain only static members
    // Static members do not require an instance
    // Static members must be called using type name
    // Static members can only refer to other static members

    // Extension methods
    //   In a static public/internal class
    //   Must be a static method
    //   First parameter must be preceded by this

    /// <summary>Seeds a movie database.</summary>
    public static class SeedDatabase
    {        
        /// <summary>Seeds a database with movies.</summary>
        /// <param name="database">The database to seed.</param>
        public static void Seed ( this IMovieDatabase database )
        {            
            database.Add(new Movie() {
                Title = "Jaws",
                Genre = "Horror",
                ReleaseYear = 1977,
                Duration = 124,
                Rating = "PG",
                IsClassic = true
            });

            database.Add(new Movie() {
                Title = "Star Wars",
                Genre = "Science Fiction",
                ReleaseYear = 1977,
                Duration = 145,
                Rating = "PG",
                IsClassic = true
            });
            
            database.Add(new Movie() {
                Title = "Dune",
                Genre = "Science Fiction",
                ReleaseYear = 1984,
                Duration = 244,
                Rating = "PG"
            });
        }
    }
}
