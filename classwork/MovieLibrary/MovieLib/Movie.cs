using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLib
{    
    /// <summary>Represents a movie.</summary>
    public class Movie  // : IValidatableObject
    {        
        /// <summary>Gets the minimum release year.</summary>
        public const int MinimumReleaseYear = 1900;

        /// <summary>Gets the minimum release date.</summary>
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);

        /// <summary>Gets or sets the title of the movie.</summary>
        //[RequiredAttribute()]
        //[RequiredAttribute]
        [Required(AllowEmptyStrings = false)]
        public string Title
        {
            get => _title ?? "";
            set => _title = value?.Trim();
        }
        private string _title;
        
        /// <summary>Gets or sets the duration in minutes.</summary>
        [RangeAttribute(0, Int32.MaxValue)]
        public int Duration { get; set; }

        /// <summary>Gets or sets the release year.</summary>
        [RangeAttribute(MinimumReleaseYear, 2100)]
        public int ReleaseYear { get; set; } = 1900;

        /// <summary>Gets or sets the rating.</summary>
        //[RequiredAttribute()]
        [Required(AllowEmptyStrings = false)]
        public string Rating
        {
            get => !String.IsNullOrEmpty(_rating) ? _rating : "";
            set => _rating = value;
        }
        private string _rating;

        /// <summary>Gets or sets the genre.</summary>
        //[RequiredAttribute()]
        [Required(AllowEmptyStrings = false)]
        public string Genre
        {
            get { return !String.IsNullOrEmpty(_genre) ? _genre : ""; }
            set { _genre = value; }
        }
        private string _genre;

        /// <summary>Gets or sets if the movie is a classic.</summary>
        public bool IsClassic { get; set; }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return !String.IsNullOrEmpty(_description) ? _description : ""; }
            set { _description = value; }
        }
        private string _description;

        /// <summary>Determines if the movie is black and white.</summary>
        [Obsolete("Do not use")]
        public bool IsBlackAndWhite => ReleaseYear <= 1939;
        
        /// <summary>Gets the unique ID of the movie.</summary>
        public int Id { get; set; }

        //Expression body
        public override string ToString () => $"{Title} ({ReleaseYear})";        

        public Movie Copy () => new Movie() {
                Id = Id,
                Title = Title,
                Description = Description,
                Duration = Duration,
                ReleaseYear = ReleaseYear,
                Genre = Genre,
                Rating = Rating,
                IsClassic = IsClassic
            };
               
        public void CopyFrom ( Movie source )
        {
            Title = source.Title;
            Description = source.Description;
            Duration = source.Duration;
            ReleaseYear = source.ReleaseYear;
            Genre = source.Genre;
            Rating = source.Rating;
            IsClassic = source.IsClassic;
        }

        /// <summary>Validates the instance.</summary>
        /// <returns>Returns error message if any or empty string otherwise.</returns>
        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{
        //    ////Title is required
        //    //if (String.IsNullOrEmpty(_title))
        //    //    yield return new ValidationResult("Title is required", new[] { nameof(Title) });

        //    //if (Duration < 0)
        //    //    yield return new ValidationResult("Duration must be at least 0", new[] { nameof(Duration) });

        //    //if (ReleaseYear < MinimumReleaseYear)
        //    //    yield return new ValidationResult($"Release Year must be at least {MinimumReleaseYear}",
        //    //                     new[] { nameof(ReleaseYear) });

        //    //if (String.IsNullOrEmpty(Rating))
        //    //    yield return new ValidationResult("Rating is required", new[] { nameof(Rating) });

        //    //if (String.Equals(_title, "Error", StringComparison.OrdinalIgnoreCase))
        //    //    yield return new ValidationResult("Title cannot be 'error'", new[] { nameof(Title) });            
        //}

        private void ShouldNotUse ()
        {
            var isSet = IsBlackAndWhite;
        }
    }    
}
