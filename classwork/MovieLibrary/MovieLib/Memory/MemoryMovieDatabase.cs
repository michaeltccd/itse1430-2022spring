using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieLib.Memory
{
    /// <summary>Provides an in-memory movie database.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {                
        protected override Movie AddCore ( Movie movie )
        {
            if (String.Equals(movie.Title, "MemoryError", StringComparison.OrdinalIgnoreCase))
                throw new IOException("Bad memory");

            movie.Id = _id++;
            _movies.Add(movie.Copy());
            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
                _movies.Remove(movie);
            //foreach (var item in _movies)
            //{
            //    if (item.Id == id)
            //    {
            //        _movies.Remove(item);
            //        return;
            //    };
            //};
        }

        protected override Movie GetCore ( int id )
        {
            return FindById(id)?.Copy();
        }

        //Iterators - implementation of IEnumerable<T>
        // Defer executes the method such that the method is called piecemeal on demand

        protected override IEnumerable<Movie> GetAllCore ()
        {
            //Need to clone movies so changes outside database do not impact our copy
            //return _movies.ToArray();
            //var items = new Movie[_movies.Count];
            //var index = 0;
            //Approach 1
            //foreach (var movie in _movies)
            //{
            //    //System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");
            //    //items[index++] = movie.Copy();
            //    yield return movie.Copy();
            //};

            //return items;

            //Approach 2
            return _movies.Select(x => x.Copy());
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            //Update            
            var existing = FindById(id);            
            existing.CopyFrom(movie);            
        }

        //Not visible in interface
        public void Foo () { }

        #region Private Members

        private Movie FindById ( int id )
        {
            //LINQ:
            //   What :: Data desired  entire movie
            //   Where:: IEnumerable<T> _movies
            //   When :: Condition ids match

            //Approach 1
            //IEnumerable<Movie> matches = _movies.Where(IsMatchingId);
            //var match = matches.FirstOrDefault();

            //Approach 2
            //var movie = _movies.Where(IsMatchingId)
            //   (Movie item) => item.Id == id
            //var movie = _movies.Where(item => item.Id == id)
            //                   .FirstOrDefault();
            //return movie;

            //Approach 3
            return _movies.FirstOrDefault(x => x.Id == id);

            //Approach 4
            //foreach (var item in _movies)
            //{
            //    if (item.Id == id)
            //        return item;
            //};

            //return null;
        }

        //Func<Movie, bool>
        //private bool IsMatchingId ( Movie movie )
        //{
        //    return false;
        //}

        protected override Movie FindByName ( string name )
        {
            //Foreach rules
            // 1. loop variant is readonly
            // 2. Array cannot change
            //Approach 1
            //foreach (var movie in _movies)
            //    if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
            //        return movie;

            //return null;

            //Approach 2
            //return _movies.FirstOrDefault(x => String.Equals(x.Title, name, StringComparison.CurrentCultureIgnoreCase));

            return (from m in _movies
                    where String.Equals(m.Title, name, StringComparison.CurrentCultureIgnoreCase)
                    select m).FirstOrDefault();
        }

        private readonly List<Movie> _movies = new List<Movie>();

        //Simple identifier system
        private int _id = 1;
        #endregion
    }
}
