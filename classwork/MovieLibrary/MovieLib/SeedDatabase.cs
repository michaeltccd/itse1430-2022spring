﻿using System;

using MovieLib.Memory;

namespace MovieLib
{
    /// <summary>Seeds a movie database.</summary>
    public class SeedDatabase
    {
        /// <summary>Seeds a database with movies.</summary>
        /// <param name="database">The database to seed.</param>
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
