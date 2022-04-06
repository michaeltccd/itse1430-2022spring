using System.Collections.Generic;

namespace MovieLib.Memory
{
    public interface IMovieDatabase
    {
        string Add ( Movie movie );
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        string Update ( int id, Movie movie );
    }
}