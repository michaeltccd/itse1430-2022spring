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
        // Naming: nouns, camel cased, start with underscore
        //   Readable and writable (assuming accessibility)
        //   Work just like all other variables
        // Do not expose publicly
        public const int MinimumReleaseYear = 1900;
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);


        //Properties - exposes data
        //  Field syntax with methods being called
        //  Can get (read) and/or set (write)
        //    T getter ()
        //    void setter ( T value )

        // Handling null
        //   null coalescing ::= E ?? E, find first non-null
        //   null conditional ::= E?.M, execute M if E not null, changes type to T?
        //   combined ::= E?.M ?? D, resets type back to T            

        /// <summary>Gets or sets the title of the movie.</summary>
        public string Title
        {
            //get { return !String.IsNullOrEmpty(_title) ? _title : ""; }
            //get { return (_title != null) ? _title : ""; }
            get { return _title ?? ""; }

            //set { _title = (value != null ) ? value.Trim() : null; }
            //set { _title = (value ?? "").Trim(); }
            set { _title = value?.Trim(); }
        }
        private string _title;

        //Auto property syntax when property is simply reading/writing backing field
        /// <summary>Gets or sets the duration in minutes.</summary>
        public int Duration { get; set; }

        public int ReleaseYear { get; set; } = 1900;
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;

        public string Rating
        {
            get { return !String.IsNullOrEmpty(_rating) ? _rating : ""; }
            set { _rating = value; }
        }
        private string _rating;

        public string Genre
        {
            get { return !String.IsNullOrEmpty(_genre) ? _genre : ""; }
            set { _genre = value; }
        }
        private string _genre;

        public bool IsClassic { get; set; }
        
        public string Description
        {
            get { return !String.IsNullOrEmpty(_description) ? _description : ""; }
            set { _description = value; }
        }
        private string _description;

        //Calculated property := BW <= 1939
        // No setter so it cannot be written to
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear <= 1939; }
            //set { }
        }
        //private bool _isBlackAndWhite;

        //private void CalculateBlackAndWhite ()
        //{
        //    _isBlackAndWhite = ReleaseYear <= 1939;
        //}

        //All instance methods have a hidden this parameter that represents the instance
        /// <summary>Validates the instance.</summary>
        /// <returns>Returns error message if any or empty string otherwise.</returns>
        public string Validate ( /* Movie this */ )
        {
            //var title = "";

            //Title is required
            if (String.IsNullOrEmpty(_title))
                return "Title is required";

            if (Duration < 0)
            //if (this.duration < 0)
                return "Duration must be at least 0";

            if (ReleaseYear < MinimumReleaseYear)
                return $"Release Year must be at least {MinimumReleaseYear}";

            if (String.IsNullOrEmpty(Rating))
                return "Rating is required";

            //Special rule - no classic movies before 1940
            if (IsClassic && ReleaseYear < 1940)
                return "Release Year must be at least 1940 to be a classic";

            return "";
        }

        public int Id { get; private set; }
        //{
        //    //Mixed acessibility
        //    // Only on either getter or setter
        //    // Must be more restrictive than property
        //    get { return _id; }
        //    private set { _id = value; }
        //}
        //private int _id;
    }
}
