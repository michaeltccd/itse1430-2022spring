using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using MovieLib.Memory;

namespace MovieLib.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //If database is empty
            IEnumerable<Movie> items = _movies.GetAll();            
            if (!items.Any())
            {
                if (MessageBox.Show(this, "Do you want to seed the database?", "Seed",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Seed database                    
                    //SeedDatabase.Seed(_movies);
                    _movies.Seed();
                    UpdateUI();
                };
            };
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            //Confirm exit
            DialogResult dr = MessageBox.Show(this, "Are you sure you want to quit?", "Quit",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                e.Cancel = true;
        }

        #region Command Handlers

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();

            //Show modally - blocking call
            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save movie
                //var error = _movies.Add(dlg.Movie);
                //if (String.IsNullOrEmpty(error))
                //{
                //    dlg.Movie.Title = "Star Wars";
                //    UpdateUI();
                //    return;
                //};
                _movies.Add(dlg.Movie);
                UpdateUI();
                return;

                //MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = movie;

            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Update movie
                _movies.Update(movie.Id, dlg.Movie);
                UpdateUI();
                return;
                
                //MessageBox.Show(this, error, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Confirm delete
            if (MessageBox.Show(this, $"Are you sure you want to delete {movie.Title}?", "Delete",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //TODO: Delete
            _movies.Delete(movie.Id);
            UpdateUI();
        }

        private void Foo () => throw new NotImplementedException();

        #endregion

        #region Private Members

        private Movie GetSelectedMovie ()
        {
            return _lstMovies.SelectedItem as Movie;
        }

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();

            //Approach 1
            //foreach (var movie in movies)
            //    _lstMovies.Items.Add(movie);

            //Approach 2
            //var movies = _movies.GetAll()
            //                    .OrderBy(x => x.Title)
            //                    .ThenBy(x => x.ReleaseYear);

            //Approach 3
            var movies = from m in _movies.GetAll()
                         orderby m.Title, m.ReleaseYear
                         select m;

            _lstMovies.Items.AddRange(movies.ToArray());
        }

        private readonly IMovieDatabase _movies = new MemoryMovieDatabase();

        #endregion
    }
}
