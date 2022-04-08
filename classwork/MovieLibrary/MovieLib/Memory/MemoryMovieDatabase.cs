using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLib.Memory
{
    /// <summary>Provides an in-memory movie database.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {                
        protected override Movie AddCore ( Movie movie )
        {                        
            movie.Id = _id++;
            _movies.Add(movie.Copy());
            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            //Find by movie.Id;
            foreach (var item in _movies)
            {
                if (item.Id == id)
                {
                    _movies.Remove(item);
                    return;
                };
            };
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
            foreach (var movie in _movies)
            {
                //System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");
                //items[index++] = movie.Copy();
                yield return movie.Copy();
            };

            //return items;
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
            foreach (var item in _movies)
            {
                if (item.Id == id)
                    return item;
            };

            return null;
        }

        protected override Movie FindByName ( string name )
        {
            //Foreach rules
            // 1. loop variant is readonly
            // 2. Array cannot change
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
                    return movie;

            return null;
        }

        private readonly List<Movie> _movies = new List<Movie>();

        //Simple identifier system
        private int _id = 1;
        #endregion
    }
}
