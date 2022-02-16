using System;

namespace MovieLib
{
    // Class - wraps data and functionality
    //   Naming: nouns, Pascal cased
    //   Default accessibility: internal for a class, private for a class member

    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        //Access modifiers
        //  public - everyone
        //  internal - assembly only
        //  private - declaring type

        //Fields - where the data is stored
        // Naming: nouns, camel cased
        //   Readable and writable (assuming accessibility)
        //   Work just like all other variables
        //  

        /// <summary>Gets or sets the title of the movie.</summary>
        public string title;
        public int duration;
        public int releaseYear = 1900;
        public string rating;
        public string genre;
        public bool isColor;
        public string description;

        private int id;
    }
}
