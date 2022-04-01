using System;

using MovieLib.Memory;

namespace MovieLib
{
    /// <summary>Seeds a movie database.</summary>
    public class SeedDatabase
    {
        public void Seed ( MemoryMovieDatabase database )
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

            var item = new Movie() {
                Title = "Dune",
                Genre = "Science Fiction",
                ReleaseYear = 1984,
                Duration = 244,
                Rating = "PG"
            };
            //database.Add(item);
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
