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
}
