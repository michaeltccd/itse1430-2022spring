using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLib
{
    public class MovieDatabase
    {
        //Constructor chaining - one constructor calls another one
        public MovieDatabase () : this("My Movies")
        {
            // Do minimal init of instance, if any
            // Don't init fields - use field initializers
            // Unless
            //   Depends on other fields
            //   Relies on data available after initialization
        }

        //Bad init approach
        //private void Initialize ()
        //{
        //    _id = 1;
        //}

        public MovieDatabase ( string name ) 
        {
            //Initialize();
            _id = 1;

            Name = name;
        }
        //private string _name;
        private int _id;

        public string Name { get; set; }

        //Virtual means derived types can override but base type has default implementation
        //Override means a derived type is overriding a base type's implementation
        public virtual void Add ( Movie movie )
        {
        }

        public void Delete ( Movie movie )
        { }

        public Movie Find ( string name )
        {
            return null;
        }

        public Movie Get ()
        {
            return null;
        }

        public void Update ( Movie movie )
        { }

        protected void Foo () { }
    }

    public class MemoryMovieDatabase : MovieDatabase
    {
        public MemoryMovieDatabase () : base("Memory Movies")
        {
        }

        public override void Add ( Movie movie )
        {
            base.Add(movie);
        }
    }
}
