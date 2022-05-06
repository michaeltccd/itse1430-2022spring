using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLib.WebApp.Models
{    
    /// <summary>Represents a movie.</summary>
    public class MovieViewModel
    {    
        public MovieViewModel ()
        { }

        public MovieViewModel ( Movie movie )
        {
            Id = movie.Id;
            Title = movie.Title;
            
            Duration = movie.Duration;
            ReleaseYear = movie.ReleaseYear;

            Rating = movie.Rating;
            Genre = movie.Genre;
            Description = movie.Description;

            IsClassic = movie.IsClassic;            
        }

        public Movie ToMovie () => new Movie() {
            Title = Title,
            Duration = Duration,
            ReleaseYear = ReleaseYear,
            Rating = Rating,
            Genre = Genre,
            Description = Description,
            IsClassic = IsClassic
        };

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
                
        [RangeAttribute(0, Int32.MaxValue)]
        public int Duration { get; set; }
        
        [Display(Name = "Release Year")]
        [RangeAttribute(Movie.MinimumReleaseYear, 2100)]
        public int ReleaseYear { get; set; } = Movie.MinimumReleaseYear;

        [Required(AllowEmptyStrings = false)]
        public string Rating { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }

        [Display(Name = "Is Classic")]
        public bool IsClassic { get; set; }
        
        public string Description { get; set; }

        public int Id { get; set; }
    }    
}
